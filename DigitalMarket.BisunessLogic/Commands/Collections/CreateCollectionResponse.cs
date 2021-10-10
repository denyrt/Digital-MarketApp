using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public record CreateCollectionResponse : ResponseBase<CreateCollectionResponse>
    {
        public Collection Collection { get; init; }

        public static CreateCollectionResponse FromSuccess(DigitalCollection digitalCollection)
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
