using E_Commerce_Try2.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Try2.AppDbContext
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shopping_Card> Shopping_Cards { get; set; }
    }
}
