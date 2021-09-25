using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket.Controllers
{
    [Route("Sign-In")]
    public class SignInController : Controller
    {
        public SignInController(IMediator mediator)
        {
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {            
            return View();
        }

        [HttpGet("Registry")]
        public IActionResult Registry()
        {
            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            return Redirect("~/Home/Index");
        }
    }
}
