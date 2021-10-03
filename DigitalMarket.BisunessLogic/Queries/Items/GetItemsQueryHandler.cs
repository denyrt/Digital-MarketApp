using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Items
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, GetItemsResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetItemsQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetItemsResponse> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _digitalMarketDbContext.DigitalItems
                .Include(x => x.DigitalCollection)
                .Include(x => x.DigitalRarity)
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);

            return GetItemsResponse.FromSuccess(items);
        }
    }
}
