using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public record DeleteRaritiesCommand : IRequest<DeleteRaritiesResponse>
    {
        public Guid[] Ids { get; init; }
    }
}
