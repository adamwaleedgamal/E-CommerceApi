using E_Commerce_Try2.AppDbContext;
using E_Commerce_Try2.Dtos;
using E_Commerce_Try2.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Try2.Repositorys.RepoCustomer
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly dbcontext _context;

        public CustomerRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddCustomer(GetAllCustomer dto)
        {
            var result = new Customer
            {
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                CustomerPhone = dto.CustomerPhone, 
                Order = dto.OrdersDto.Select(x => new Order
                {
                    Price = x.Price,
                    Product = x.ProductDto.Select(t => new Product
                    {
                        ProductName = t.ProductName,
                        ProductDescription = t.ProductDescription,
                        ProductQuantity = t.ProductQuantity,
                    }).ToList(),
                }).ToList(),
                Shopping_Card = new Shopping_Card
                {
                    Shopping_CardName = dto.Shopping_CardDto.Shopping_CardName,
                }
            };
            _context.Customers.Add(result);
            _context.SaveChanges();
        }

        public List<GetAllCustomer> GetAllCustomers()
        {
            var result = _context.Customers
                .Include(x => x.Order)
                .ThenInclude(x => x.Product)
                .Include(x => x.Shopping_Card)
                .Select(i => new GetAllCustomer
                {
                    CustomerEmail = i.CustomerEmail,
                    CustomerName = i.CustomerName,
                    CustomerPhone = i.CustomerPhone,
                    OrdersDto = i.Order.Select(t=> new OrderDto
                    {
                        Price = t.Price,
                        ProductDto = t.Product.Select(c=> new ProductDto
                        {
                            ProductDescription = c.ProductDescription,
                            ProductName = c.ProductName,
                            ProductQuantity= c.ProductQuantity,
                        }).ToList()
                    }).ToList(),
                    Shopping_CardDto = new CardDto
                    {
                        Shopping_CardName = i.Shopping_Card.Shopping_CardName,
                    }
                }).ToList();


            return result;
        }

        public GetAllCustomer GetCustomerById(int id)
        {
            var result = _context.Customers.Include(x => x.Order).
                ThenInclude(x => x.Product).
                Include(x => x.Shopping_Card).
                FirstOrDefault(x => x.CustomerId == id);

            return new GetAllCustomer
            {
                CustomerName = result.CustomerName,
                CustomerPhone = result.CustomerPhone,
                CustomerEmail = result.CustomerEmail,
                OrdersDto = result.Order.Select(t => new OrderDto
                {
                    Price= t.Price,
                    ProductDto = t.Product.Select(c => new ProductDto
                    {
                        ProductDescription= c.ProductDescription,
                        ProductName = c.ProductName,
                        ProductQuantity= c.ProductQuantity, 
                    }).ToList(),
                }).ToList(),
                Shopping_CardDto = new CardDto
                {
                    Shopping_CardName = result.Shopping_Card.Shopping_CardName,
                }
            };
        }
    }
}
