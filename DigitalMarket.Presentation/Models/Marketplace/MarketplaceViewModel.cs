using DigitalMarket.BisunessLogic.Models;

namespace DigitalMarket.Presentation.Models.Marketplace
{
    public record MarketplaceViewModel
    {
        public SellOffer[] SellOffers { get; init; }
    }
}