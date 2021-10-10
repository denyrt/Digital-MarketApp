using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public record DeleteCollectionsResponse : ResponseBase<DeleteCollectionsResponse>
    {
        public int DeletedCount { get; init; }

        public static DeleteCollectionsResponse FromSuccess(int deletedCount)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                DeletedCount = deletedCount
            };
        }
    }
}
