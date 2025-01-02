using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Try2.Dtos
{
    public class CardDto
    {
        [Required]
        public string Shopping_CardName { get; set; }
    }
}
