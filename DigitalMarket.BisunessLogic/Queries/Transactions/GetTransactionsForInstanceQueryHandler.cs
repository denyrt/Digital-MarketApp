using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Transactions
{
    public class GetTransactionsForInstanceQueryHandler : IRequestHandler<GetTransactionsForInstanceQuery, GetTransactionsForInstanceResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetTransactionsForInstanceQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }
        
        public async Task<GetTransactionsForInstanceResponse> Handle(GetTransactionsForInstanceQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _digitalMarketDbContext.DigitalTransactions
                .OrderBy(x => x.CreateTimeUtc)
                .Reverse()
                .Where(x => x.InstanceId == request.InstanceId)
                .Skip(request.PageOffset * request.CountInPage)
                .Take(request.CountInPage)
                .AsNoTracking()
                .ToArrayAsync();

            return GetTransactionsForInstanceResponse.FromSuccess(transactions);
        }
    }
}
