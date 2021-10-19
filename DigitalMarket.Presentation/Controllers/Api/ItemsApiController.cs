using DigitalMarket.BisunessLogic.Commands.Items;
using DigitalMarket.BisunessLogic.Queries.Items;
using DigitalMarket.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Presentation.Controllers.Api
{
    [Route("api/items")]
    [ApiController]
    public class ItemsApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetItemQuery { Id = id });
            return result.ToActionResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetItems([FromQuery] GetItemsQuery query)
        {
            var result = await _mediator.Send(query);
            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemCommand command)
        {
            CreateItemResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateItemCommand command)
        {
            UpdateItemResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem([FromBody] DeleteItemsCommand command)
        {
            DeleteItemsResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }
    }
}
