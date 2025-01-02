using E_Commerce_Try2.Models;

namespace E_Commerce_Try2.Dtos
{
    public class AddCardCustomerDto
    {
        public string Shopping_CardName { get; set; }
        public CustomerDto CustomerDto { get; set; }
    }
}
