using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.BisunessLogic.Queries.Rarities
{
    public record GetRaritiesResponse : ResponseBase<GetRaritiesResponse>
    {
        public Rarity[] Rarities { get; init; }

        public static GetRaritiesResponse FromSuccess(IEnumerable<DigitalRarity> rarities)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                Rarities = rarities.Select(digitalRarity => digitalRarity.ToRarity()).ToArray()
            };
        }
    }
}
