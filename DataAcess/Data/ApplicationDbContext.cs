using DataAcess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CoffeShop> CoffeShops { get; set; }
    }
}
