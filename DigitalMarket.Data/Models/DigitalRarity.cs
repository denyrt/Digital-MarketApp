using System;
using System.Collections.Generic;

namespace DigitalMarket.Data.Models
{
    public class DigitalRarity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DigitalItem> DigitalItems { get; set; }
    }
}
