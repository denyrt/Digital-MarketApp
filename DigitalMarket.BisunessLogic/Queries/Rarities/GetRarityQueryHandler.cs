using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Rarities
{
    public class GetRarityQueryHandler : IRequestHandler<GetRarityQuery, GetRarityResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public GetRarityQueryHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<GetRarityResponse> Handle(GetRarityQuery request, CancellationToken cancellationToken)
        {
            var keyValues = new object[] { request.Id };
            var rarity = await _digitalMarketDbContext.DigitalRarities.FindAsync(keyValues, cancellationToken);
            if (rarity == null)
            {
                return GetRarityResponse.FromError(ResponseCodes.NotFound);
            }

            return GetRarityResponse.FromSuccess(rarity);
        }
    }
}
