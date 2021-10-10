using MediatR;

namespace DigitalMarket.BisunessLogic.Commands.Email
{
    public record ConfirmEmailCommand : IRequest<bool>
    {
        public string Username { get; init; }
        public string Token { get; init; }
    }
}