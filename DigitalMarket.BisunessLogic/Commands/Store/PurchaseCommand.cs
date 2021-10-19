using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Store
{
    public record PurchaseCommand : IRequest<PurchaseCommandResponse>
    {
        public Guid BuyerId { get; init; }
        public Guid CollectionId { get; init; }
    }
}
