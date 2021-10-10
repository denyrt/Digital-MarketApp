using MediatR;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public record ResetPasswordCommand : IRequest<ResetPasswordResponse>
    {
        public string Email { get; init; }

        public string Password { get; init; }

        public string Token { get; init; }
    }
}
