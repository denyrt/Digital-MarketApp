using System;
using System.Collections.Generic;

namespace DigitalMarket.Data.Models
{
    public class DigitalItem
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string MarketName { get; set; }
        public Guid DigitalCollectionId { get; set; }
        public DigitalCollection DigitalCollection { get; set; }
        public Guid DigitalRarityId { get; set; }
        public DigitalRarity DigitalRarity { get; set; }
        public string Description { get; set; }
        public double DropChance { get; set; }
        public DateTime CreateDateUtc { get; set; } = DateTime.UtcNow;
        public List<DigitalItemInstance> ItemInstances { get; set; }
    }
}
