using DigitalMarket.Data.Models;
using MediatR;

namespace DigitalMarket.BisunessLogic.Commands.Email
{
    public record SendConfirmEmailLetterCommand : IRequest<bool>
    {
        public DigitalUser DigitalUser { get; init; }
    }
}