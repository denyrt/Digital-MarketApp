using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace DigitalMarket.Presentation.Extensions
{
    public static class ActionResultExtensions
    {
        public static IActionResult ToActionResult(this ResponseBase responseBase)
        {
            return responseBase.Code switch
            {
                ResponseCodes.Ok => new OkObjectResult(responseBase),
                ResponseCodes.NotFound => new NotFoundObjectResult(responseBase),
                ResponseCodes.Conflict => new ConflictObjectResult(responseBase),
                _ => new BadRequestObjectResult(responseBase)
            };
        }
    }
}
