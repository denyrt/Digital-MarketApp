using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket.Presentation.Controllers.Mvc
{
    public class MarketplaceController : Controller
    {
        private readonly IMediator _mediator;

        public MarketplaceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
