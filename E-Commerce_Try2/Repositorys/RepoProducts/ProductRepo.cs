using E_Commerce_Try2.AppDbContext;
using E_Commerce_Try2.Dtos;
using E_Commerce_Try2.Models;

namespace E_Commerce_Try2.Repositorys.RepoProducts
{
    public class ProductRepo : IProductsRepo
    {
        private readonly dbcontext _context;

        public ProductRepo(dbcontext context)
        {
            _context = context;
        }

        public void AddProduct(ProductDto dto)
        {
            var result = new Product
            {
                ProductDescription = dto.ProductDescription,
                ProductName = dto.ProductName,  
                ProductQuantity = dto.ProductQuantity,
            };
            _context.Products.Add(result);
            _context.SaveChanges();
        }
    }
}
