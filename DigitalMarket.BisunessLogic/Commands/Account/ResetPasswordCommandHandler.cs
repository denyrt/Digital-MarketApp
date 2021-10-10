using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
    {
        private readonly AspNetUserManager<DigitalUser> _aspNetUserManager;

        public ResetPasswordCommandHandler(AspNetUserManager<DigitalUser> aspNetUserManager)
        {
            _aspNetUserManager = aspNetUserManager;
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            DigitalUser user = await _aspNetUserManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return ResetPasswordResponse.FromError(ResponseCodes.Conflict);
            }

            IdentityResult result = await _aspNetUserManager.ResetPasswordAsync(user, request.Token, request.Password);
            return result.Succeeded ? ResetPasswordResponse.SuccessResponse : ResetPasswordResponse.FromIdentityErrors(result.Errors);
        }
    }
}