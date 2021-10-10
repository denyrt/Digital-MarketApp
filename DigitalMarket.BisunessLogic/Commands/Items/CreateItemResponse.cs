using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public record CreateItemResponse : ResponseBase<CreateItemResponse>
    {
        public Item Item { get; init; }

        public static CreateItemResponse FromSuccess(DigitalItem digitalItem)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                Item = digitalItem.ToItem()
            };
        }
    }
}
