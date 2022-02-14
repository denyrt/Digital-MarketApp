using DigitalMarket.BisunessLogic.Models;
using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Marketplace
{
    public class GetInstanceQueryHandler : IRequestHandler<GetInstanceQuery, GetInstanceResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetInstanceQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetInstanceResponse> Handle(GetInstanceQuery request, CancellationToken cancellationToken)
        {
            var instance = await _digitalMarketDbContext.DigitalItemInstances
                .Include(x => x.DigitalItem)
                .ThenInclude(x => x.DigitalCollection)
                .Include(x => x.DigitalItem.DigitalRarity)
                .Include(x => x.DigitalSellOffer)
                .Include(x => x.Owner)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (instance == null)
            {
                return GetInstanceResponse.FromError(ResponseCodes.NotFound);
            }

            var lastTransactions = await _digitalMarketDbContext.DigitalTransactions
                .Where(x => x.InstanceId == request.Id)
                .OrderBy(x => x.CreateTimeUtc)
                .Take(5)
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);

            return new GetInstanceResponse
            {
                Success = true,
                Code = ResponseCodes.Ok,
                InstanceId = instance.Id,
                OwnerName = instance.Owner.UserName,
                SellOffer = instance.DigitalSellOffer?.ToSellOffer(),
                Item = instance.DigitalItem?.ToItem(),
                LastTransactions = lastTransactions.Select(x => x.ToTransaction()).ToArray()
            };
        }
    }
}
