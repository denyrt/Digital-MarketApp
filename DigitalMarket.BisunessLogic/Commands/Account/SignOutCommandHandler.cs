using DigitalMarket.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public class SignOutCommandHandler : IRequestHandler<SignOutCommand, SignOutResponse>
    {
        private readonly SignInManager<DigitalUser> _signInManager;

        public SignOutCommandHandler(SignInManager<DigitalUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignOutResponse> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return SignOutResponse.SuccessResponse;
        }
    }
}
