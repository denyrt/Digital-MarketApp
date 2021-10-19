using DigitalMarket.Application.Interfaces;
using DigitalMarket.BisunessLogic.Commands.Store;
using DigitalMarket.BisunessLogic.Queries.Collections;
using DigitalMarket.BisunessLogic.Queries.Items;
using DigitalMarket.Presentation.Controllers.Mvc;
using DigitalMarket.Presentation.Models.Store;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Controllers
{
    [Route("Store")]
    public class StoreController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly IMediator _mediator;

        public StoreController(IUserHelper userHelper, IMediator mediator)
        {
            _mediator = mediator;
            _userHelper = userHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetCollectionsQuery { OnlyAvailable = true });
            
            if (result.Success)
            {
                return View(result.Collections);
            }

            return NotFound();
        }

        [HttpGet("Collection/{id}")]
        public async Task<IActionResult> Collection([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetCollectionQuery { Id = id });
            return View(response);
        }

        [HttpGet("Item/{id}")]
        public async Task<IActionResult> Item([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetItemQuery { Id = id });
            return View(response.Item);
        }

        [HttpGet("Purchase/{id}")]
        [Authorize]
        public async Task<IActionResult> Purchase([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetCollectionQuery { Id = id });
            return response.Success ? View(new PurchaseViewModel { Collection = response.Collection }) : NotFound();
        }

        [HttpPost("Purchase/{id}")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakePurchase([FromRoute] Guid id)
        {
            var currentUser = await _userHelper.GetCurrentUser();
            var command = new PurchaseCommand { BuyerId = currentUser.Id, CollectionId = id };
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return RedirectToAction(nameof(InventoryController.Index));
            }

            return Ok(result);
        }
    }
}
