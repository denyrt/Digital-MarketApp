using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Collections
{
    public record GetCollectionQuery : IRequest<GetCollectionResponse>
    {
        public Guid Id { get; init; }
    }
}
