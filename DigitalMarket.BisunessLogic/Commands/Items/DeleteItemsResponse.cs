using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public record DeleteItemsResponse : ResponseBase<DeleteItemsResponse>
    {
        public int DeletedCount { get; init; }

        public static DeleteItemsResponse FromSuccess(int deletedCount)
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
