using MediatR;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public record CreateRarityCommand : IRequest<CreateRarityResponse>
    {
        public string Name { get; init; }
    }
}
