using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Marketplace
{
    public class GetSellOffersQueryHandler : IRequestHandler<GetSellOffersQuery, GetSellOffersResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetSellOffersQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetSellOffersResponse> Handle(GetSellOffersQuery request, CancellationToken cancellationToken)
        {
            var sellOffersQuery = _digitalMarketDbContext.DigitalSellOffers
                .Include(x => x.ItemInstance)
                .ThenInclude(x => x.DigitalItem)
                .ThenInclude(x => x.DigitalRarity)
                .Include(x => x.ItemInstance.DigitalItem.DigitalCollection)
                .OrderBy(x => x.CreateDateUtc)
                .AsQueryable();

            if (request.OwnerId.HasValue)
            {
                sellOffersQuery = sellOffersQuery.Where(x => x.ItemInstance.OwnerId == request.OwnerId);
            }

            var result = await sellOffersQuery
                .Skip(request.PageOffset * request.CountInPage)
                .Take(request.CountInPage)
                .Select(x => new SellOffer
                {
                    Id = x.Id,
                    InstanceId = x.InstanceId,
                    Item = x.ItemInstance.DigitalItem.ToItem(),
                    Price = x.Price
                })
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);

            return new GetSellOffersResponse
            {
                Success = true,
                Code = ResponseCodes.Ok,
                SellOffers = result
            };
        }
    }
}
