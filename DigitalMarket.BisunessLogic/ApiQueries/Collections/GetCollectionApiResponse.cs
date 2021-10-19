using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using System;
using System.Linq;

namespace DigitalMarket.BisunessLogic.ApiQueries.Collections
{
    public record GetCollectionApiResponse : ResponseBase<GetCollectionApiResponse>
    {
        public Collection Collection { get; init; }
        public Item[] Items { get; init; }

        public static GetCollectionApiResponse FromSuccess(DigitalCollection digitalCollection)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                Collection = digitalCollection.ToCollection(),
                Items = digitalCollection.DigitalItems?.Select(x => x.ToItem())?.ToArray() ?? Array.Empty<Item>()
            };
        }
    }
}
