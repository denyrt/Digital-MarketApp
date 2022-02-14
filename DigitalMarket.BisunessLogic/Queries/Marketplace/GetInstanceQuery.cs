using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Marketplace
{
    public record GetInstanceQuery : IRequest<GetInstanceResponse>
    {
        public Guid Id { get; init; }
    }
}
