using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.ApiQueries.Collections
{
    public record GetCollectionApiQuery : IRequest<GetCollectionApiResponse>
    {
        public Guid Id { get; init; }
    }
}
