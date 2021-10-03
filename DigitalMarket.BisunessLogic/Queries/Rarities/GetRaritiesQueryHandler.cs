using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Rarities
{
    public class GetRaritiesQueryHandler : IRequestHandler<GetRaritiesQuery, GetRaritiesResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetRaritiesQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetRaritiesResponse> Handle(GetRaritiesQuery request, CancellationToken cancellationToken)
        {
            var rarities = await _digitalMarketDbContext.DigitalRarities.ToArrayAsync(cancellationToken);
            return GetRaritiesResponse.FromSuccess(rarities);
        }
    }
}
