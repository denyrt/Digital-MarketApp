using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, UpdateItemResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public UpdateItemCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<UpdateItemResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var itemKeys = new object[] { request.Id };
            var item = await _digitalMarketDbContext.DigitalItems.FindAsync(itemKeys, cancellationToken);
            if (item == null)
            {
                return UpdateItemResponse.FromError(ResponseCodes.NotFound);
            }

            var rarityKeys = new object[] { request.RarityId };
            var rarity = await _digitalMarketDbContext.DigitalRarities.FindAsync(rarityKeys, cancellationToken);
            if (rarity == null)
            {
                return UpdateItemResponse.FromError(ResponseCodes.Conflict);
            }

            var collectionKeys = new object[] { request.CollectionId };
            var collection = await _digitalMarketDbContext.DigitalCollections.FindAsync(collectionKeys, cancellationToken);
            if (collection == null)
            {
                return UpdateItemResponse.FromError(ResponseCodes.Conflict);
            }

            item.MarketName = request.MarketName;
            item.Description = request.Description;
            item.ImageUrl = request.ImageUrl;
            item.DigitalRarityId = request.RarityId;
            item.DigitalCollectionId = request.CollectionId;
            item.DropChance = request.DropChance;
            var update = _digitalMarketDbContext.Update(item);

            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return UpdateItemResponse.FromSuccess(update.Entity);
        }
    }
}
