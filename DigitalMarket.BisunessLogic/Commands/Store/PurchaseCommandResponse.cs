using DigitalMarket.Application.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;

namespace DigitalMarket.BisunessLogic.Commands.Store
{
    public record PurchaseCommandResponse : ResponseBase<PurchaseCommandResponse>
    {
        public static PurchaseCommandResponse FromSuccess(PurchaseResult purchaseResult)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok
            };
        }
    }
}
