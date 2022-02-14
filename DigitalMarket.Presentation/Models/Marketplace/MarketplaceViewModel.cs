using DigitalMarket.BisunessLogic.Models;
using System;

namespace DigitalMarket.Presentation.Models.Marketplace
{
    public record MarketplaceViewModel
    {
        public Guid? RarityId { get; init; }
        public string Name { get; init; }
        public SellOffer[] SellOffers { get; init; }
    }
}