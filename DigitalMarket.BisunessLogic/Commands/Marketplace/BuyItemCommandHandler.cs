using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using DigitalMarket.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Marketplace
{
    public class BuyItemCommandHandler : IRequestHandler<BuyItemCommand, BuyItemResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public BuyItemCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<BuyItemResponse> Handle(BuyItemCommand request, CancellationToken cancellationToken)
        {
            var buyerKeyValue = new object[] { request.BuyerId };
            var buyer = await _digitalMarketDbContext.Users.FindAsync(buyerKeyValue, cancellationToken);
            if (buyer == null)
            {
                return BuyItemResponse.FromError(ResponseCodes.Conflict);
            }

            var offerKeyValue = new object[] { request.OfferId };
            var offer = await _digitalMarketDbContext.DigitalSellOffers.FindAsync(offerKeyValue, cancellationToken);
            if (offer == null)
            {
                return BuyItemResponse.FromError(ResponseCodes.Conflict);
            }

            var instance = await _digitalMarketDbContext.DigitalItemInstances.FirstOrDefaultAsync(x => x.Id == offer.InstanceId, cancellationToken);
            if (instance == null || instance.OwnerId == request.BuyerId)
            {
                return BuyItemResponse.FromError(ResponseCodes.Conflict);
            }

            if (offer.Price > buyer.Balance)
            {
                return BuyItemResponse.FromError("LowBalance");
            }

            var owner = await _digitalMarketDbContext.Users.FirstOrDefaultAsync(x => x.Id == instance.OwnerId, cancellationToken);
            if (owner == null)
            {
                return BuyItemResponse.FromError(ResponseCodes.Conflict);
            }

            var transaction = new DigitalTransaction
            {
                InstanceId = instance.Id,
                FromUserId = instance.OwnerId,
                ToUserId = buyer.Id,
                Price = offer.Price,
                CreateTimeUtc = DateTime.UtcNow
            };
            var addTransaction = await _digitalMarketDbContext.AddAsync(transaction, cancellationToken);

            instance.OwnerId = buyer.Id;
            buyer.Balance -= offer.Price;
            owner.Balance += offer.Price;

            _digitalMarketDbContext.DigitalItemInstances.Update(instance);
            _digitalMarketDbContext.Users.Update(buyer);
            _digitalMarketDbContext.Users.Update(owner);
            _digitalMarketDbContext.DigitalSellOffers.Remove(offer);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return BuyItemResponse.SuccessResponse;
        }
    }
}
