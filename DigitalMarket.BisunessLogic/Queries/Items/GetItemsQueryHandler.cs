using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            IQueryable<DigitalItem> query = _digitalMarketDbContext.DigitalItems
                .Include(x => x.DigitalCollection)
                .Include(x => x.DigitalRarity)
                .OrderBy(x => x.CreateDateUtc);

            if (request.CollectionId.HasValue)
            {
                query = query.Where(x => x.DigitalCollectionId == request.CollectionId.Value);
            }

            query = query.Skip(request.CountInPage * request.PageOffset).Take(request.CountInPage);

            var items = await query.AsNoTracking().ToArrayAsync(cancellationToken);
            var maxCount = await query.CountAsync(cancellationToken);

            return GetItemsResponse.FromSuccess(items, maxCount);
        }
    }
}
