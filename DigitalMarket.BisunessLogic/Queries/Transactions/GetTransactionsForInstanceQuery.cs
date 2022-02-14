using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Transactions
{
    public record GetTransactionsForInstanceQuery : IRequest<GetTransactionsForInstanceResponse>
    {
        public Guid InstanceId { get; init; }
        public int PageOffset { get; init; }
        public int CountInPage { get; init; }
    }
}