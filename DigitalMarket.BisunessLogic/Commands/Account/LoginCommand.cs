using MediatR;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public record LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; init; }

        public string Password { get; init; }

        public bool RememberMe { get; init; }
    }
}