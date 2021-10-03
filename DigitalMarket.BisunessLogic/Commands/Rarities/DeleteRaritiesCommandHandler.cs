using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public class DeleteRaritiesCommandHandler : IRequestHandler<DeleteRaritiesCommand, DeleteRaritiesResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public DeleteRaritiesCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<DeleteRaritiesResponse> Handle(DeleteRaritiesCommand request, CancellationToken cancellationToken)
        {
            var rarities = await _digitalMarketDbContext.DigitalRarities
                .Where(rarity => request.Ids.Contains(rarity.Id))
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);

            _digitalMarketDbContext.DigitalRarities.RemoveRange(rarities);
            var deletedCount = await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return DeleteRaritiesResponse.FromSuccess(deletedCount);
        }
    }
}
