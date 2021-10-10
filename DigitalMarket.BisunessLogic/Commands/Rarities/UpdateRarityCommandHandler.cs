using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public class UpdateRarityCommandHandler : IRequestHandler<UpdateRarityCommand, UpdateRarityResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public UpdateRarityCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<UpdateRarityResponse> Handle(UpdateRarityCommand request, CancellationToken cancellationToken)
        {
            var keyValues = new object[] { request.Id };
            var rarity = await _digitalMarketDbContext.DigitalRarities.FindAsync(keyValues, cancellationToken);
            if (rarity == null)
            {
                return UpdateRarityResponse.FromError(ResponseCodes.NotFound);
            }

            rarity.Name = request.Name;
            var update = _digitalMarketDbContext.Update(rarity);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return UpdateRarityResponse.FromSuccess(update.Entity);
        }
    }
}
