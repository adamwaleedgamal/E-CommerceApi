using E_Commerce_Try2.Dtos;
using E_Commerce_Try2.Repositorys.RepoOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Try2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _repo;

        public OrderController(IOrderRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repo.GetAllOrders();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDto dto)
        {
            _repo.AddOrder(dto);
            if (dto != null)
            {
                return Ok(dto);
            }
            else
            {
                return BadRequest();
            
            }
        }

        [HttpPut]
        public IActionResult UpdateOrder(OrderDto dto, int id)
        {
            _repo.UpdateOrder(dto, id);
            if (dto != null)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
