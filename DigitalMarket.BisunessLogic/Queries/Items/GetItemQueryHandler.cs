using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Items
{
    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, GetItemResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetItemQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetItemResponse> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _digitalMarketDbContext.DigitalItems
                .Include(x => x.DigitalRarity)
                .Include(x => x.DigitalCollection)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (item == null)
            {
                return GetItemResponse.FromError(ResponseCodes.NotFound);
            }

            return GetItemResponse.FromSuccess(item);
        }
    }
}
