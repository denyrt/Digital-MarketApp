using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Transactions
{
    public record GetTransactionsQuery : IRequest<GetTransactionsResponse>
    {
        public Guid UserId { get; init; }
        public int PageOffset { get; init; }
        public int CountInPage { get; init; }
    }
}
