using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public record CreateRarityResponse : ResponseBase<CreateRarityResponse>
    {
        public Rarity Rarity { get; init; }

        public static CreateRarityResponse FromSuccess(DigitalRarity rarity)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Success,
                Rarity = rarity.ToRarity()
            };
        }
    }
}
