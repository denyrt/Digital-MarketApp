using DigitalMarket.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.SignIn
{
    public class RegistryCommandHandler : IRequestHandler<RegistryCommand, RegistryResponse>
    {
        private readonly AspNetUserManager<DigitalUser> _aspNetUserManager;

        public RegistryCommandHandler(AspNetUserManager<DigitalUser> aspNetUserManager)
        {
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
                var message = result.Errors.Select(e => e.Code).FirstOrDefault();
                return RegistryResponse.FromError(message);
            }

            return RegistryResponse.SuccessResponse;
        }
    }
}
