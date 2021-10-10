using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly SignInManager<DigitalUser> _signInManager;

        public LoginCommandHandler(SignInManager<DigitalUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            DigitalUser user = await _signInManager.UserManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return LoginResponse.FromError(ResponseCodes.InvalidCredentials);
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            return LoginResponse.FromSignInResult(signInResult);
        }
    }
}
