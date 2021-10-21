using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Marketplace
{
    public record CancelSellOfferCommand : IRequest<CancelSellOfferResponse>
    {
        public Guid Id { get; init; }
    }
}
