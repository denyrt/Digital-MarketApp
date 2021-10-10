using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public record UpdateCollectionResponse : ResponseBase<UpdateCollectionResponse>
    {
        public Collection Collection { get; init; }

        public static UpdateCollectionResponse FromSuccess(DigitalCollection digitalCollection) 
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                Collection = digitalCollection.ToCollection()
            };
        }
    }
}
