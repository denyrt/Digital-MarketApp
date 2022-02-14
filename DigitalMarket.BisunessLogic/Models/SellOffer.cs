using DigitalMarket.Data.Models;
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

    public static class SellOfferMapping
    {
        public static SellOffer ToSellOffer(this DigitalSellOffer digitalSellOffer)
        {
            return new()
            {
                Id = digitalSellOffer.Id,
                InstanceId = digitalSellOffer.InstanceId,
                Item = digitalSellOffer.ItemInstance?.DigitalItem?.ToItem(),
                Price = digitalSellOffer.Price
            };
        }
    }
}
