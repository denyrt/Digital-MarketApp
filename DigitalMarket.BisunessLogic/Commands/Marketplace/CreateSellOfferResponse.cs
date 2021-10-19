using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Marketplace
{
    public record CreateSellOfferResponse : ResponseBase<CreateSellOfferResponse>
    {
        public Guid SellOfferId { get; init; }

        public static CreateSellOfferResponse FromSuccess(Guid sellOfferId)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                SellOfferId = sellOfferId
            };
        }
    }
}
