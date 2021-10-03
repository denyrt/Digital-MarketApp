using DigitalMarket.Data.Models;
using System;

namespace DigitalMarket.BisunessLogic.Models
{
    public record Collection
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }

    public static class CollectionMappingExtensions
    {
        public static Collection ToCollection(this DigitalCollection digitalCollection) => new()
        {
            Id = digitalCollection.Id,
            Name = digitalCollection.Name,
            Description = digitalCollection.Description
        };
    }
}
