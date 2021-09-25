using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
