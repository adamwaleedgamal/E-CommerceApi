using E_Commerce_Try2.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Try2.Dtos
{
    public class GetAllCustomer
    {
        [Required]
        public string CustomerName { get; set; }
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Phone]
        public string CustomerPhone { get; set; }
        public List<OrderDto> OrdersDto { get; set; }
        public CardDto Shopping_CardDto { get; set; }
    }
}
