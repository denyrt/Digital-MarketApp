using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public record UpdateItemResponse : ResponseBase<UpdateItemResponse>
    {
        public Item Item { get; set; }

        public static UpdateItemResponse FromSuccess(DigitalItem digitalItem)
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
