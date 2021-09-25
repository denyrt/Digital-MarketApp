using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
