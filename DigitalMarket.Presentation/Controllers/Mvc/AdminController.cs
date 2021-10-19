using DigitalMarket.BisunessLogic.Commands.Collections;
using DigitalMarket.BisunessLogic.Queries.Collections;
using DigitalMarket.BisunessLogic.Queries.Items;
using DigitalMarket.BisunessLogic.Queries.Rarities;
using DigitalMarket.Presentation.Models.Admin;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Presentation.Controllers.Mvc
{
    [Route("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ManageCollections")]
        public async Task<IActionResult> ManageCollections()
        {
            var collections = await _mediator.Send(new GetCollectionsQuery { OnlyAvailable = false });
            return View(new ManageCollectionsViewModel { Collections = collections.Collections });
        }

        [HttpGet("CreateCollection")]
        public IActionResult CreateCollection()
        {
            return View();
        }

        [HttpPost("CreateCollection")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCollection([FromForm] CreateCollectionViewModel createCollectionViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createCollectionViewModel);
            }

            CreateCollectionResponse response = await _mediator.Send(createCollectionViewModel.ToCommand());
            
            if (response.Success)
            {
                return RedirectToAction(nameof(ManageCollections));
            }

            ViewBag.Failed = true;
            ViewBag.Code = response.Code;

            return View(createCollectionViewModel);
        }

        [HttpGet("EditCollection/{id}")]
        public async Task<IActionResult> EditCollection([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetCollectionQuery { Id = id });
           
            if (!response.Success)
            {
                return NotFound();
            }

            var viewModel = new EditCollectionViewModel
            {
                Id = response.Collection.Id,
                Name = response.Collection.Name,
                Description = response.Collection.Description,
                ImageUrl = response.Collection.Image,
                Price = response.Collection.Price
            };

            return View(viewModel);
        }

        [HttpPost("EditCollection/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCollection([FromForm] EditCollectionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _mediator.Send(model.ToCommand());
            if (response.Success)
            {
                return RedirectToAction(nameof(ManageCollections));
            }

            ViewBag.Failed = true;
            ViewBag.Code = response.Code;

            return View(model);
        }

        [HttpGet("ManageItems")]
        public async Task<IActionResult> ManageItems()
        {
            var response = await _mediator.Send(new GetItemsQuery { CountInPage = 20, PageOffset = 0 });
            var viewModel = new ManageItemsViewModel
            {
                Items = response.Items
            };
            var collectionsResponse = await _mediator.Send(new GetCollectionsQuery { OnlyAvailable = false });
            ViewBag.Collections = collectionsResponse.Collections;
            return View(viewModel);
        }
        
        [HttpGet("CreateItem")]
        public async Task<IActionResult> CreateItem()
        {
            ViewBag.Rarities = (await _mediator.Send(new GetRaritiesQuery())).Rarities;
            ViewBag.Collections = (await _mediator.Send(new GetCollectionsQuery())).Collections;

            return View();
        }

        [HttpPost("CreateItem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem([FromForm] CreateItemViewModel createItemViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createItemViewModel);
            }

            var response = await _mediator.Send(createItemViewModel.ToCommand());
            if (!response.Success)
            {
                ViewBag.Failed = true;
                ViewBag.Code = response.Code;
                return View(createItemViewModel);
            }

            return RedirectToAction(nameof(ManageItems), createItemViewModel.CollectionId);
        }

        [HttpGet("EditItem/{id}")]
        public async Task<IActionResult> EditItem([FromRoute] Guid id)
        {
            var getItemResponse = await _mediator.Send(new GetItemQuery { Id = id });
            if (!getItemResponse.Success)
            {
                return NotFound();
            }

            var viewModel = new EditItemViewModel
            {
                Id = getItemResponse.Item.Id,
                MarketName = getItemResponse.Item.MarketName,
                Description = getItemResponse.Item.Description,
                DropChance = getItemResponse.Item.DropChance,
                ImageUrl = getItemResponse.Item.ImageUrl,
                CollectionId = getItemResponse.Item.Collection.Id,
                RarityId = getItemResponse.Item.Rarity.Id
            };

            ViewBag.Rarities = (await _mediator.Send(new GetRaritiesQuery())).Rarities;
            ViewBag.Collections = (await _mediator.Send(new GetCollectionsQuery())).Collections;

            return View(viewModel);
        }

        [HttpPost("EditItem/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditItem([FromForm] EditItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var response = await _mediator.Send(viewModel.ToCommand());
            if (!response.Success)
            {
                ViewBag.Failed = true;
                ViewBag.Code = response.Code;
                return View(viewModel);
            }

            return RedirectToAction(nameof(ManageItems));
        }
    }
}