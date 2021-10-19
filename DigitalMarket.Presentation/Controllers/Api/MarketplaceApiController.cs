using DigitalMarket.Application.Interfaces;
using DigitalMarket.BisunessLogic.Commands.Marketplace;
using DigitalMarket.BisunessLogic.Queries.Marketplace;
using DigitalMarket.Presentation.Extensions;
using DigitalMarket.Presentation.Models.Marketplace;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MarketplaceApiController : ControllerBase
    {
        private readonly IUserHelper _userHelper;
        private readonly IMediator _mediator;

        public MarketplaceApiController(IUserHelper userHelper, IMediator mediator)
        {
            _userHelper = userHelper;
            _mediator = mediator;
        }

        [HttpPost("CreateSellOffer")]
        public async Task<IActionResult> CreteSellOffer([FromBody] CreateSellOfferViewModel request)
        {
            var currentUser = await _userHelper.GetCurrentUser();
            var response = await _mediator.Send(new CreateSellOfferCommand 
            { 
                InstanceId = request.InstanceId, 
                Price = request.Price,
                UserId = currentUser.Id
            });
            return response.ToActionResult();
        }

        [HttpGet("SellOffers")]
        public async Task<IActionResult> GetSellOffers([FromQuery] GetSellOffersQuery query)
        {
            var response = await _mediator.Send(query);
            return response.ToActionResult();
        }

        [HttpPost("BuyItem/{offerId}")]
        public async Task<IActionResult> BuyItem([FromRoute] Guid offerId)
        {
            var currentUser = await _userHelper.GetCurrentUser();
            var response = await _mediator.Send(new BuyItemCommand { BuyerId = currentUser.Id, OfferId = offerId });
            return response.ToActionResult();
        }
    }
}
