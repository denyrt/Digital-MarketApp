using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public record UpdateRarityCommand : IRequest<UpdateRarityResponse>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
