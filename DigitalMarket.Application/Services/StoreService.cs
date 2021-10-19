using DigitalMarket.Application.Interfaces;
using DigitalMarket.Application.Models;
using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public StoreService(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<PurchaseResult> PurchaseAsync(DigitalUser buyer, DigitalCollection collection, CancellationToken cancellationToken)
        {
            if (buyer == null) throw new ArgumentNullException(nameof(buyer));
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            if (buyer.Balance < collection.Price)
            {
                return PurchaseResult.FromError(PurchaseMessages.LowBalance);
            }

            var items = await _digitalMarketDbContext.DigitalItems
                .Where(x => x.DigitalCollectionId == collection.Id)
                .ToArrayAsync();

            if (!collection.AvailableAtMarket || items.Sum(x => x.DropChance) != 100d || !TryRollItem(items, out var item))
            {
                return PurchaseResult.FromError(PurchaseMessages.Unavailable);
            }

            var instance = new DigitalItemInstance
            {
                ItemId = item.Id,
                OwnerId = buyer.Id
            };

            var addedInstance = await _digitalMarketDbContext.DigitalItemInstances.AddAsync(instance, cancellationToken);
            var transaction = new DigitalTransaction
            {
                FromUserId = buyer.Id,
                ToUserId = buyer.Id,
                InstanceId = addedInstance.Entity.Id,
                Price = collection.Price,
                CreateTimeUtc = DateTime.UtcNow
            };

            buyer.Balance -= collection.Price;
            _digitalMarketDbContext.Users.Update(buyer);

            await _digitalMarketDbContext.DigitalTransactions.AddAsync(transaction, cancellationToken);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);

            return PurchaseResult.FromSuccess(item);
        }

        private static bool TryRollItem(IEnumerable<DigitalItem> digitalItems, out DigitalItem item)
        {
            var random = new Random();
            var roll = random.NextDouble();
            var additionalCoefficient = 0d;
            
            foreach (var entry in digitalItems.OrderBy(x => x.DropChance))
            {
                var decimalChance = entry.DropChance / 100d;
                var currentCoefficient = decimalChance + additionalCoefficient;
                if (roll <= currentCoefficient) 
                {
                    item = entry;
                    return true;
                }
                additionalCoefficient += decimalChance;
            }

            item = null;
            return false;
        }
    }
}
