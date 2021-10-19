using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Marketplace
{
    public record CreateSellOfferCommand : IRequest<CreateSellOfferResponse>
    {
        public Guid UserId { get; init; }
        public Guid InstanceId { get; init; }
        public double Price { get; init; }
    }
}
