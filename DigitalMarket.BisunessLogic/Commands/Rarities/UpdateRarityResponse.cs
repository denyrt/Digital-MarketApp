using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public record UpdateRarityResponse : ResponseBase<UpdateRarityResponse>
    {
        public Rarity Rarity { get; init; }

        public static UpdateRarityResponse FromSuccess(DigitalRarity digitalRarity)
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