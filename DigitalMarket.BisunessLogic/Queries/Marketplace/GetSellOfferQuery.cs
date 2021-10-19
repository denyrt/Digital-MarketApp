using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Marketplace
{
    public record GetSellOfferQuery : IRequest<GetSellOfferResponse>
    {
        public Guid Id { get; init; }
    }
}
