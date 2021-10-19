using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Collections
{
    public class GetCollectionsQueryHandler : IRequestHandler<GetCollectionsQuery, GetCollectionsResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetCollectionsQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetCollectionsResponse> Handle(GetCollectionsQuery request, CancellationToken cancellationToken)
        {
            var collections = _digitalMarketDbContext.DigitalCollections.AsQueryable();
            if (request.OnlyAvailable)
            {
                collections = collections.Where(x => x.AvailableAtMarket);
            }
            var fetch = await collections.ToArrayAsync(cancellationToken);
            return GetCollectionsResponse.FromSuccess(fetch);
        }
    }
}
