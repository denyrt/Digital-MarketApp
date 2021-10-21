using DigitalMarket.Application.Interfaces;
using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Marketplace
{
    public class CancelSellOfferCommandHandler : IRequestHandler<CancelSellOfferCommand, CancelSellOfferResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;
        private readonly IUserHelper _userHelper;

        public CancelSellOfferCommandHandler(DigitalMarketDbContext digitalMarketDbContext, IUserHelper userHelper)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
            _userHelper = userHelper;
        }

        public async Task<CancelSellOfferResponse> Handle(CancelSellOfferCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userHelper.GetCurrentUser();
            var sellOffer = await _digitalMarketDbContext.DigitalSellOffers.FindAsync(request.Id);
            if (sellOffer == null)
            {
                return CancelSellOfferResponse.FromError(ResponseCodes.Conflict);
            }

            var instance = await _digitalMarketDbContext.DigitalItemInstances.FindAsync(sellOffer.InstanceId);
            if (instance == null || instance.OwnerId != currentUser.Id)
            {
                return CancelSellOfferResponse.FromError(ResponseCodes.Conflict);
            }

            _digitalMarketDbContext.DigitalSellOffers.Remove(sellOffer);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return CancelSellOfferResponse.SuccessResponse;
        }
    }
}
