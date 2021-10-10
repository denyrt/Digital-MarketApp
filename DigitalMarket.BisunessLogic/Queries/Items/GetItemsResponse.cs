using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.BisunessLogic.Queries.Items
{
    public record GetItemsResponse : ResponseBase
    {
        public Item[] Items { get; init; }

        public static GetItemsResponse FromSuccess(IEnumerable<DigitalItem> digitalItems)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                Items = digitalItems.Select(digitalItem => digitalItem.ToItem()).ToArray()
            };
        }
    }
}
