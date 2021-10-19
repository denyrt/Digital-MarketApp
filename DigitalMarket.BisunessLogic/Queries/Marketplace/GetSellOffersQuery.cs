using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Marketplace
{
    public record GetSellOffersQuery : IRequest<GetSellOffersResponse>
    {
        public Guid? OwnerId { get; init; }
        public int PageOffset { get; init; }
        public int CountInPage { get; init; }
    }
}
