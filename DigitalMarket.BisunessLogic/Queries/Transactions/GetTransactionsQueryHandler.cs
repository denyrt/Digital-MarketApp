using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Transactions
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, GetTransactionsResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetTransactionsQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetTransactionsResponse> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _digitalMarketDbContext.DigitalTransactions
                .Where(x => x.FromUserId == request.UserId || x.ToUserId == request.UserId)
                .OrderBy(x => x.CreateTimeUtc)
                .Reverse()
                .Include(x => x.ItemInstance)
                .ThenInclude(instance => instance.DigitalItem)
                .Skip(request.PageOffset * request.CountInPage)
                .Take(request.CountInPage)
                .AsNoTracking()
                .ToArrayAsync();

            return GetTransactionsResponse.FromSuccess(transactions);
        }
    }
}
