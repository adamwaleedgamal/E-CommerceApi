using E_Commerce_Try2.AppDbContext;
using E_Commerce_Try2.Dtos;
using E_Commerce_Try2.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Try2.Repositorys.RepoOrder
{
    public class OrderRepo : IOrderRepo
    {
        private readonly dbcontext _context;

        public OrderRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddOrder(OrderDto dto)
        {
            var result = new Order
            {
                Price = dto.Price,
                Product = dto.ProductDto.Select(x=>new Product
                {
                    ProductDescription = x.ProductDescription,
                    ProductName = x.ProductName,
                    ProductQuantity = x.ProductQuantity,
                }).ToList(),
            };
            _context.Orders.Add(result);
            _context.SaveChanges();
        }

        public List<GetAllOrder> GetAllOrders()
        {
            var result = _context.Orders.Include(x=>x.Product).
                Include(x=>x.Customer).
                Select(t => new GetAllOrder
                {
                    Price = t.Price,
                    ProductDto = t.Product.Select(c=>new ProductDto
                    {
                        ProductDescription = c.ProductDescription,
                        ProductName = c.ProductName,
                        ProductQuantity = c.ProductQuantity,
                    }).ToList(),
                    CustomerDto = new CustomerDto
                    {
                        CustomerEmail = t.Customer.CustomerEmail,
                        CustomerName = t.Customer.CustomerName,
                        CustomerPhone = t.Customer.CustomerPhone,
                    }
                }).ToList();
            return result;
        }

        public void UpdateOrder(OrderDto dto, int id)
        {
            var result = _context.Orders.Include(x=>x.Product).
                FirstOrDefault(x=> x.OrderId == id);

            if(result != null)
            {
                result.Price = dto.Price;
                result.Product = dto.ProductDto.Select(t=> new Product
                {
                    ProductDescription= t.ProductDescription,
                    ProductName = t.ProductName,
                    ProductQuantity = t.ProductQuantity,
                }).ToList();
            }
            else
            {
                throw new Exception("Id Not Found");
            }
            _context.Orders.Update(result);
            _context.SaveChanges();
        }
    }
}
