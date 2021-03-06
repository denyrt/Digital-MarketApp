using DigitalMarket.BisunessLogic.Commands.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DigitalMarket.Controllers.Api
{
    [Route("api/sign-in")]
    [ApiController]
    public class SignInApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SignInApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginQuery)
        {
            LoginResponse response = await _mediator.Send(loginQuery);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("registry")]
        public async Task<IActionResult> Registry([FromBody] RegistryCommand registryQuery)
        {
            RegistryResponse response = await _mediator.Send(registryQuery);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
