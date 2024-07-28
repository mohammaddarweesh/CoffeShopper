using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeShopController : ControllerBase
    {
        private readonly ICoffeShopService _coffeShopService;

        public CoffeShopController(ICoffeShopService coffeShopService)
        {
            this._coffeShopService = coffeShopService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var coffeShops = await _coffeShopService.List();
            return Ok(coffeShops);
        }
    }
}
