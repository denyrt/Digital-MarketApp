using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.BisunessLogic.Queries.Collections
{
    public record GetCollectionsResponse : ResponseBase<GetCollectionsResponse>
    {
        public Collection[] Collections { get; init; }

        public static GetCollectionsResponse FromSuccess(IEnumerable<DigitalCollection> digitalCollections)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                Collections = digitalCollections.Select(collection => collection.ToCollection()).ToArray()
            };
        }
    }
}
