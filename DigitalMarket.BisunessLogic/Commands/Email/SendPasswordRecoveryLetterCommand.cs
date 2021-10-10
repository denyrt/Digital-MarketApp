using MediatR;

namespace DigitalMarket.BisunessLogic.Commands.Email
{
    public record SendPasswordRecoveryLetterCommand : IRequest<bool>
    {
        public string Email { get; init; }
    }
}