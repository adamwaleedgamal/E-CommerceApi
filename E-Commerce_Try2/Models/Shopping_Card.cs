namespace E_Commerce_Try2.Models
{
    public class Shopping_Card
    {
        public int Shopping_CardId { get; set; }
        public string Shopping_CardName { get; set; }
        public Customer Customer { get; set; }
    }
}
