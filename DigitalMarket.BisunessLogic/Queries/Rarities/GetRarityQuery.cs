using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Rarities
{
    public record GetRarityQuery : IRequest<GetRarityResponse>
    {
        public Guid Id { get; init; }
    }
}
