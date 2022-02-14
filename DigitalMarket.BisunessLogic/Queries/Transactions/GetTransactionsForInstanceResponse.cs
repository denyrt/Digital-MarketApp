using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.BisunessLogic.Responses;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMarket.BisunessLogic.Queries.Transactions
{
    public record GetTransactionsForInstanceResponse : ResponseBase<GetTransactionsForInstanceResponse>
    {
        public Transaction[] Transactions { get; init; }

        public static GetTransactionsForInstanceResponse FromSuccess(IEnumerable<DigitalTransaction> digitalTransactions)
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
