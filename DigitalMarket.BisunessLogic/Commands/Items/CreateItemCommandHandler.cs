using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public CreateItemCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<CreateItemResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var rarityKeys = new object[] { request.RarityId };
            var rarity = await _digitalMarketDbContext.DigitalRarities.FindAsync(rarityKeys, cancellationToken);
            if (rarity == null)
            {
                return CreateItemResponse.FromError(ResponseCodes.Conflict);
            }

            var collectionKeys = new object[] { request.CollectionId };
            var collection = await _digitalMarketDbContext.DigitalCollections.FindAsync(collectionKeys, cancellationToken);
            if (collection == null)
            {
                return CreateItemResponse.FromError(ResponseCodes.Conflict);
            }
            
            var item = new DigitalItem
            {
                MarketName = request.MarketName,
                ImageUrl = request.ImageUrl,
                DropChance = request.DropChance,
                Description = request.Description,
                DigitalRarityId = request.RarityId,
                DigitalCollectionId = request.CollectionId
            };
            
            var create = await _digitalMarketDbContext.AddAsync(item, cancellationToken);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return CreateItemResponse.FromSuccess(create.Entity);
        }
    }
}
