using DigitalMarket.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public class DeleteItemsCommandHandler : IRequestHandler<DeleteItemsCommand, DeleteItemsResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public DeleteItemsCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<DeleteItemsResponse> Handle(DeleteItemsCommand request, CancellationToken cancellationToken)
        {
            var items = await _digitalMarketDbContext.DigitalItems
                .Where(item => request.Ids.Contains(item.Id))
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);

            _digitalMarketDbContext.DigitalItems.RemoveRange(items);
            var deletedCount = await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return DeleteItemsResponse.FromSuccess(deletedCount);
        }
    }
}
