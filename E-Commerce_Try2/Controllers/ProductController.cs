using E_Commerce_Try2.Dtos;
using E_Commerce_Try2.Repositorys.RepoProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Try2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepo _repo;

        public ProductController(IProductsRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto dto)
        {
            _repo.AddProduct(dto);
            if(dto != null)
            {
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
