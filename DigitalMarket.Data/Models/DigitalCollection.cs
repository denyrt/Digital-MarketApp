using System;
using System.Collections.Generic;

namespace DigitalMarket.Data.Models
{
    public class DigitalCollection
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AvailableAtMarket { get; set; }
        public double Price { get; set; }
        public List<DigitalItem> DigitalItems { get; set; }
    }
}