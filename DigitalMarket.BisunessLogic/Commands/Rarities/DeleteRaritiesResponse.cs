using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public record DeleteRaritiesResponse : ResponseBase<DeleteRaritiesResponse>
    {
        public int DeletedCount { get; init; }

        public static DeleteRaritiesResponse FromSuccess(int deletedCount)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Success,
                DeletedCount = deletedCount
            };
        }
    }
}