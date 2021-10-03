using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Queries.Collections
{
    public record GetCollectionResponse : ResponseBase<GetCollectionResponse>
    {
        public Collection Collection { get; init; }

        public static GetCollectionResponse FromSuccess(DigitalCollection digitalCollection)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Success,
                Collection = digitalCollection.ToCollection()
            };
        }
    }
}
