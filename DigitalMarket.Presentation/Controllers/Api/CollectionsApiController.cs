using DigitalMarket.BisunessLogic.Commands.Collections;
using DigitalMarket.BisunessLogic.Queries.Collections;
using DigitalMarket.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Presentation.Controllers.Api
{
    [Route("api/collections")]
    [ApiController]
    public class CollectionsApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CollectionsApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollection([FromRoute] Guid id)
        {
            GetCollectionResponse result = await _mediator.Send(new GetCollectionQuery { Id = id });
            return result.ToActionResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetCollections()
        {
            GetCollectionsResponse result = await _mediator.Send(new GetCollectionsQuery());
            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCollection([FromBody] CreateCollectionCommand command)
        {
            CreateCollectionResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCollection([FromBody] UpdateCollectionCommand command)
        {
            UpdateCollectionResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCollections([FromBody] DeleteCollectionsCommand command)
        {
            DeleteCollectionsResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }
    }
}
