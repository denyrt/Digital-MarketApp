using DigitalMarket.Application.Interfaces;
using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.Data.Contexts;
using DigitalMarket.Presentation.Models.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalMarket.Presentation.Controllers.Mvc
{
    public class InventoryController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public InventoryController(IUserHelper userHelper, DigitalMarketDbContext digitalMarketDbContext)
        {
            _userHelper = userHelper;
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {            
            var currentUser = await _userHelper.GetCurrentUser();
            var instances = await _digitalMarketDbContext.DigitalItemInstances
                .Include(x => x.DigitalSellOffer)
                .Include(x => x.DigitalItem)
                .ThenInclude(item => item.DigitalCollection)
                .Include(x => x.DigitalItem.DigitalRarity)
                .Where(x => x.OwnerId == currentUser.Id)
                .AsNoTracking()
                .ToArrayAsync();

            return View(instances.Select(x => new ItemInstanceViewModel 
                {
                    Id = x.Id,
                    Item = x.DigitalItem.ToItem(),
                    SellOfferId = x.DigitalSellOffer?.Id,
                    Price = x.DigitalSellOffer?.Price
                }).ToArray());
        }
    }
}
