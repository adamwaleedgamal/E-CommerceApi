using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Try2.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public Order Order { get; set; }
    }
}
