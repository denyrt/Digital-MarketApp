using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.ApiQueries.Collections
{
    public class GetCollectionApiQueryHandler : IRequestHandler<GetCollectionApiQuery, GetCollectionApiResponse>
    {
        private readonly DigitalMarketDbContext _context;

        public GetCollectionApiQueryHandler(DigitalMarketDbContext context)
        {
            _context = context;
        }
        
        public async Task<GetCollectionApiResponse> Handle(GetCollectionApiQuery request, CancellationToken cancellationToken)
        {
            var collection = await _context.DigitalCollections
                .Include(x => x.DigitalItems)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (collection == null)
            {
                return GetCollectionApiResponse.FromError(ResponseCodes.NotFound);
            }

            return GetCollectionApiResponse.FromSuccess(collection);
        }
    }
}
