using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;

namespace DigitalMarket.BisunessLogic.Queries.Marketplace
{
    public record GetSellOffersResponse : ResponseBase<GetSellOffersResponse>
    {
        public SellOffer[] SellOffers { get; init; }
    }
}
