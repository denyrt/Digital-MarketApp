using DigitalMarket.Data.Models;
using System;

namespace DigitalMarket.BisunessLogic.Models
{
    public record Rarity
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }

    public static class RarityMappingExtensions
    {
        public static Rarity ToRarity(this DigitalRarity digitalRarity) => new()
        {
            Id = digitalRarity.Id,
            Name = digitalRarity.Name
        };
    }
}
