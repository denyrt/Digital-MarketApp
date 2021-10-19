using DigitalMarket.Data.Models;
using System;

namespace DigitalMarket.BisunessLogic.Models
{
    public record Item
    {
        public Guid Id { get; init; }
        public string MarketName { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public double DropChance { get; init; }
        public Collection Collection { get; init; }
        public Rarity Rarity { get; init; }
    }

    public static class ItemMappingExtensions
    {
        public static Item ToItem(this DigitalItem digitalItem) => new()
        {
            Id = digitalItem.Id,
            MarketName = digitalItem.MarketName,
            Description = digitalItem.Description.Trim(),
            ImageUrl = digitalItem.ImageUrl,
            DropChance = digitalItem.DropChance,
            Collection = digitalItem?.DigitalCollection?.ToCollection(),
            Rarity = digitalItem?.DigitalRarity?.ToRarity()
        };
    }
}
