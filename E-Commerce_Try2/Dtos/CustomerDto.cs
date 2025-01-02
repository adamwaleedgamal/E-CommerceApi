using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Try2.Dtos
{
    public class CustomerDto
    {
        [Required]
        public string CustomerName { get; set; }
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Phone]
        public string CustomerPhone { get; set; }
    }
}
