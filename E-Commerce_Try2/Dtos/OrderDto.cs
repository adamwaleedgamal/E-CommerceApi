using E_Commerce_Try2.Models;

namespace E_Commerce_Try2.Dtos
{
    public class OrderDto
    {
        public int Price { get; set; }
        public List<ProductDto> ProductDto { get; set; }
    }
}
