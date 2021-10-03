using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Collections
{
    public class GetCollectionQueryHandler : IRequestHandler<GetCollectionQuery, GetCollectionResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetCollectionQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetCollectionResponse> Handle(GetCollectionQuery request, CancellationToken cancellationToken)
        {
            var keyValues = new object[] { request.Id };
            var collection = await _digitalMarketDbContext.DigitalCollections.FindAsync(keyValues, cancellationToken);
            if (collection == null)
            {
                return GetCollectionResponse.FromError(ResponseCodes.NotFound);
            }

            return GetCollectionResponse.FromSuccess(collection);
        }
    }
}
