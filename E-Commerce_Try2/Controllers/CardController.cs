using Azure.Core;
using E_Commerce_Try2.Dtos;
using E_Commerce_Try2.Repositorys.RepoCard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Try2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepo _repo;
        public CardController(ICardRepo repo) 
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddShoppingCard(AddCardCustomerDto dto)
        {
            _repo.AddShoppingCard(dto);
            return Ok(dto);
        }
    }
}
