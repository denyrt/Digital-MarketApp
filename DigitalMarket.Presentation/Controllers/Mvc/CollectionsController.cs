using DigitalMarket.BisunessLogic.Queries.Collections;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalMarket.Presentation.Controllers.Mvc
{
    public class CollectionsController : Controller
    {
        private readonly IMediator _mediator;

        public CollectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Collections/{id}")]
        public async Task<IActionResult> Collection([FromRoute] Guid id)
        {
            var response = await _mediator.Send(new GetCollectionQuery { Id = id });
            return View(response.Collection);
        }
    }
}
