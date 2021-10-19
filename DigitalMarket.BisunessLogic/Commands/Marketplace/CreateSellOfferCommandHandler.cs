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
    public class CreateSellOfferCommandHandler : IRequestHandler<CreateSellOfferCommand, CreateSellOfferResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public CreateSellOfferCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<CreateSellOfferResponse> Handle(CreateSellOfferCommand request, CancellationToken cancellationToken)
        {
            var instance = await _digitalMarketDbContext.DigitalItemInstances
                .Include(x => x.DigitalSellOffer)
                .FirstOrDefaultAsync(x => x.Id == request.InstanceId, cancellationToken);

            if (instance.OwnerId != request.UserId)
            {
                return CreateSellOfferResponse.FromError(ResponseCodes.Conflict);
            }

            if (instance.DigitalSellOffer != null)
            {
                return CreateSellOfferResponse.FromError(ResponseCodes.Conflict);
            }

            var sellOffer = new DigitalSellOffer
            {
                InstanceId = instance.Id,
                CreateDateUtc = DateTime.UtcNow,
                Price = request.Price
            };
            
            var addedSellOffer = await _digitalMarketDbContext.DigitalSellOffers.AddAsync(sellOffer, cancellationToken);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);

            return CreateSellOfferResponse.FromSuccess(addedSellOffer.Entity.Id);
        }
    }
}
