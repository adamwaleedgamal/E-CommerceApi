using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Try2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Phone]
        public string CustomerPhone { get; set; }
        public List<Order> Order { get; set; }
        public int Shopping_CardId { get; set; }
        public Shopping_Card Shopping_Card { get; set; }
    }
}
