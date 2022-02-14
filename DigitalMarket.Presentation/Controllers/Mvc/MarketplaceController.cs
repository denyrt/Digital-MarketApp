using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Queries.Collections;
using DigitalMarket.BisunessLogic.Queries.Marketplace;
using DigitalMarket.BisunessLogic.Queries.Rarities;
using DigitalMarket.Presentation.Models.Marketplace;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Presentation.Controllers.Mvc
{
    public class MarketplaceController : Controller
    {
        private readonly IMediator _mediator;

        public MarketplaceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var raritiesResponse = await _mediator.Send(new GetRaritiesQuery());
            ViewBag.Rarities = raritiesResponse.Rarities;

            var collectionsResponse = await _mediator.Send(new GetCollectionsQuery());
            ViewBag.Collections = collectionsResponse.Collections;

            var response = await _mediator.Send(new GetSellOffersQuery { CountInPage = 25, PageOffset = 0 });
            return View(new MarketplaceViewModel
            {
                SellOffers = response.SellOffers ?? Array.Empty<SellOffer>()
            });
        }

        [HttpGet("Instance/{id}")]
        public async Task<IActionResult> Instance([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetInstanceQuery { Id = id });
            if (!response.Success)
            {
                return NotFound();
            }

            var viewModel = new InstanceViewModel
            {
                Id = response.InstanceId,
                CurrentOwner = response.OwnerName,
                Item = response.Item,
                OfferId = response.SellOffer?.Id,
                Price = response.SellOffer?.Price,
                LastTransactions = response.LastTransactions
            };
            return View(viewModel);
        }
    }
}