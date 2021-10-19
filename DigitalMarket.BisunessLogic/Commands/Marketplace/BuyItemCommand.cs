using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Marketplace
{
    public record BuyItemCommand : IRequest<BuyItemResponse>
    {
        public Guid BuyerId { get; init; }
        public Guid OfferId { get; init; }
    }
}
