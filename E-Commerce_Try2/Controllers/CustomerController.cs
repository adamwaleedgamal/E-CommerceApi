using E_Commerce_Try2.Dtos;
using E_Commerce_Try2.Repositorys.RepoCustomer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Try2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _repo;

        public CustomerController(ICustomerRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllCustomers();
            return Ok(result);
        }
        [HttpGet ("GetByID")]
        public IActionResult GetById(int id)
        {
            var result = _repo.GetCustomerById(id);
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
        public IActionResult AddAll(GetAllCustomer dto)
        {
            _repo.AddCustomer(dto);
            return Ok();
        }
    }
}
