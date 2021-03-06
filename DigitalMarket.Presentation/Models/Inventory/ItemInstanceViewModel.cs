using DigitalMarket.BisunessLogic.Models;
using System;

namespace DigitalMarket.Presentation.Models.Inventory
{
    public record ItemInstanceViewModel
    {
        public Guid Id { get; init; }
        public Item Item { get; init; }
        public Guid? SellOfferId { get; init; }
        public double? Price { get; init; }
    }
}