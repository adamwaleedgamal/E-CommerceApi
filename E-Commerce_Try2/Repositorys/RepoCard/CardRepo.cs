using E_Commerce_Try2.AppDbContext;
using E_Commerce_Try2.Dtos;
using E_Commerce_Try2.Models;

namespace E_Commerce_Try2.Repositorys.RepoCard
{
    public class CardRepo : ICardRepo
    {
        private readonly dbcontext _context;
        public CardRepo(dbcontext context) 
        {
            _context = context;
        }

        public void AddShoppingCard(AddCardCustomerDto dto)
        {
            var result = new Shopping_Card
            {
                Shopping_CardName = dto.Shopping_CardName,
                Customer = new Customer
                {
                    CustomerName = dto.CustomerDto.CustomerName,
                    CustomerEmail = dto.CustomerDto.CustomerEmail,
                    CustomerPhone = dto.CustomerDto.CustomerPhone, 
                }
            };
            _context.Shopping_Cards.Add(result);
            _context.SaveChanges();
        }
    }
}
