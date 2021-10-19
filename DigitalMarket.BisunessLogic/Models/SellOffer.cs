using System;

namespace DigitalMarket.BisunessLogic.Models
{
    public record SellOffer
    {
        public Guid Id { get; init; }
        public Guid InstanceId { get; init; }
        public double Price { get; init; }
        public Item Item { get; init; }
    }
}
