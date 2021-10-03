using DigitalMarket.BisunessLogic.Commands.Rarities;
using DigitalMarket.BisunessLogic.Queries.Rarities;
using DigitalMarket.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Presentation.Controllers.Api
{
    [Route("api/rarities")]
    [ApiController]
    public class RaritiesApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RaritiesApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRarity([FromRoute] Guid id)
        {
            GetRarityResponse result = await _mediator.Send(new GetRarityQuery { Id = id });
            return result.ToActionResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetRarities()
        {
            GetRaritiesResponse result = await _mediator.Send(new GetRaritiesQuery());
            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRarity([FromBody] CreateRarityCommand command)
        {
            CreateRarityResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRarity([FromBody] UpdateRarityCommand command)
        {
            UpdateRarityResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRarities([FromBody] DeleteRaritiesCommand command)
        {
            DeleteRaritiesResponse result = await _mediator.Send(command);
            return result.ToActionResult();
        }
    }
}
