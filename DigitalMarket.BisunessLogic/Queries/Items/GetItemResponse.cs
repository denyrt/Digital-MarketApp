using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Queries.Items
{
    public record GetItemResponse : ResponseBase<GetItemResponse>
    {
        public Item Item { get; init; }

        public static GetItemResponse FromSuccess(DigitalItem digitalItem)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Success,
                Item = digitalItem.ToItem()
            };
        }
    }
}
