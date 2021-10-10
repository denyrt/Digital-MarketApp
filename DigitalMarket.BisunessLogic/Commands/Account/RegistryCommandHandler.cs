using DigitalMarket.BisunessLogic.Commands.Email;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public class RegistryCommandHandler : IRequestHandler<RegistryCommand, RegistryResponse>
    {
        private readonly IMediator _mediator;
        private readonly AspNetUserManager<DigitalUser> _aspNetUserManager;

        public RegistryCommandHandler(IMediator mediator, AspNetUserManager<DigitalUser> aspNetUserManager)
        {
            _mediator = mediator;
            _aspNetUserManager = aspNetUserManager;
        }

        public async Task<RegistryResponse> Handle(RegistryCommand request, CancellationToken cancellationToken)
        {
            var user = new DigitalUser
            {
                UserName = request.Username,
                Email = request.Email
            };
            
            IdentityResult result = await _aspNetUserManager.CreateAsync(user, request.Password);
            
            if (!result.Succeeded)
            {
                return RegistryResponse.FromIdentityErrors(result.Errors);
            }

            if (!await _mediator.Send(new SendConfirmEmailLetterCommand { DigitalUser = user }, cancellationToken))
            {
                await _aspNetUserManager.DeleteAsync(user);
                return RegistryResponse.FromError(ResponseCodes.Conflict);
            }

            return RegistryResponse.SuccessResponse;
        }
    }
}