using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.ApiCommands.Collections
{
    public class ChangeAvailableCommandHandler : IRequestHandler<ChangeAvailableCommand, ChangeAvailableResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public ChangeAvailableCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<ChangeAvailableResponse> Handle(ChangeAvailableCommand request, CancellationToken cancellationToken)
        {
            var collection = await _digitalMarketDbContext.DigitalCollections
                .Include(x => x.DigitalItems)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (collection == null)
            {
                return ChangeAvailableResponse.FromError(ResponseCodes.NotFound);
            }

            if (request.Available && (collection.DigitalItems.Count < 1 || collection.DigitalItems.Sum(x => x.DropChance) != 100d))
            {
                return ChangeAvailableResponse.FromError(ResponseCodes.Conflict);
            }

            collection.AvailableAtMarket = request.Available;
            _digitalMarketDbContext.DigitalCollections.Update(collection);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return ChangeAvailableResponse.SuccessResponse;
        }
    }
}
