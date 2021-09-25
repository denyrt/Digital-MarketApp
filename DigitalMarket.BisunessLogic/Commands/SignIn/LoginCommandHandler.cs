using DigitalMarket.Application.Interfaces;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.SignIn
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly AspNetUserManager<DigitalUser> _aspNetUserManager;
        private readonly IJwtFactory _jwtFactory;

        public LoginCommandHandler(
            AspNetUserManager<DigitalUser> aspNetUserManager,
            IJwtFactory jwtFactory)
        {
            _aspNetUserManager = aspNetUserManager;
            _jwtFactory = jwtFactory;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _aspNetUserManager.FindByNameAsync(request.Username);

            if (!await _aspNetUserManager.CheckPasswordAsync(user, request.Password))
            {
                return LoginResponse.FromError(ResponseMessages.InvalidCredentials);
            }

            if (!user.EmailConfirmed)
            {
                return LoginResponse.FromError(ResponseMessages.EmailNotConfirmed);
            }

            return LoginResponse.FromSuccess(_jwtFactory.GenerateJwtToken(user));
        }
    }
}
