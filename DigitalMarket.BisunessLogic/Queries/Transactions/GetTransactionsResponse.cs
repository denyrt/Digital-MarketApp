using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.BisunessLogic.Queries.Transactions
{
    public record GetTransactionsResponse : ResponseBase<GetTransactionsResponse>
    {
        public Transaction[] Transactions { get; init; }

        public static GetTransactionsResponse FromSuccess(IEnumerable<DigitalTransaction> digitalTransactions)
        {
            return new()
            {
                Success = true,
                Code = ResponseCodes.Ok,
                Transactions = digitalTransactions.Select(x => x.ToTransaction()).ToArray()
            };
        }
    }
}
