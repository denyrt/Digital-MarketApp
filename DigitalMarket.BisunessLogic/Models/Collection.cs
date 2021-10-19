using DigitalMarket.Data.Models;
using System;

namespace DigitalMarket.BisunessLogic.Models
{
    public record Collection
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Image { get; init; }
        public double Price { get; init; }
        public bool Available { get; init; }
        public string Description { get; init; }
    }

    public static class CollectionMappingExtensions
    {
        public static Collection ToCollection(this DigitalCollection digitalCollection) => new()
        {
            Id = digitalCollection.Id,
            Name = digitalCollection.Name,
            Image = digitalCollection.ImageUrl,
            Price = digitalCollection.Price,
            Available = digitalCollection.AvailableAtMarket,
            Description = digitalCollection.Description
        };
    }
}
