using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var collections = await _digitalMarketDbContext.DigitalCollections.ToArrayAsync(cancellationToken);
            return GetCollectionsResponse.FromSuccess(collections);
        }
    }
}
