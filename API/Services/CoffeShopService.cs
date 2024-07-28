using API.Models;
using DataAcess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeShopService : ICoffeShopService
    {
        private readonly ApplicationDbContext _context;

        public CoffeShopService(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        public async Task<List<CoffeShopModel>> List()
        {
            var coffeShops = await (from shop in _context.CoffeShops select new CoffeShopModel()
            {
                Id = shop.Id,
                Name = shop.Name,
                Address = shop.Address,
                OpeningHours = shop.OpeningHours,
            }).ToListAsync();

            return coffeShops;
        }
    }
}
