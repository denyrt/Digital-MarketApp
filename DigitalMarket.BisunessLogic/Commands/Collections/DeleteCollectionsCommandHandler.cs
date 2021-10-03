using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public class DeleteCollectionsCommandHandler : IRequestHandler<DeleteCollectionsCommand, DeleteCollectionsResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public DeleteCollectionsCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<DeleteCollectionsResponse> Handle(DeleteCollectionsCommand request, CancellationToken cancellationToken)
        {
            var collections = await _digitalMarketDbContext.DigitalCollections
                .Where(collection => request.Ids.Contains(collection.Id))
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);

            _digitalMarketDbContext.DigitalCollections.RemoveRange(collections);
            var deletedCount = await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return DeleteCollectionsResponse.FromSuccess(deletedCount);
        }
    }
}
