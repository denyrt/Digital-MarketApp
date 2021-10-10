using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Queries.Rarities
{
    public record GetRarityResponse : ResponseBase<GetRarityResponse>
    {
        public Rarity Rarity { get; init; }

        public static GetRarityResponse FromSuccess(DigitalRarity digitalRarity)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                Rarity = digitalRarity.ToRarity()
            };
        }
    }
}
