using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Try2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Price { get; set; }

        public List<Product> Product { get; set; }

        public Customer? Customer { get; set; }
    }
}
