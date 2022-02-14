using DigitalMarket.BisunessLogic.Models;
using System;

namespace DigitalMarket.Presentation.Models.Marketplace
{
    public record InstanceViewModel
    {
        public Guid Id { get; init; }
        public string CurrentOwner { get; init; }
        public Guid? OfferId { get; init; }
        public double? Price { get; init; }
        public Item Item { get; init; }
        public Transaction[] LastTransactions { get; init; }
    }
}