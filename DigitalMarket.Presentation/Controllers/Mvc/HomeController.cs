using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System;

namespace DigitalMarket.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CultureManagement([FromQuery] string returnUrl, [FromForm] string culture)
        {
            Response.Cookies.Append(
                key: CookieRequestCultureProvider.DefaultCookieName,
                value: CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                options: new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(30)
                });

            return LocalRedirect(returnUrl ?? "~/Home/Index");
        }
    }
}
