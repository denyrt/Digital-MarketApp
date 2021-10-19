using DigitalMarket.Application.Interfaces;
using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Store
{
    public class PurchaseCommandHandler : IRequestHandler<PurchaseCommand, PurchaseCommandResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;
        private readonly IStoreService _storeService;

        public PurchaseCommandHandler(DigitalMarketDbContext digitalMarketDbContext, IStoreService storeService)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
            _storeService = storeService;
        }

        public async Task<PurchaseCommandResponse> Handle(PurchaseCommand request, CancellationToken cancellationToken)
        {
            var collection = await _digitalMarketDbContext.DigitalCollections.FindAsync(request.CollectionId);
            if (collection == null)
            {
                return PurchaseCommandResponse.FromError(ResponseCodes.NotFound);
            }

            var user = await _digitalMarketDbContext.Users.FindAsync(request.BuyerId);
            if (user == null)
            {
                return PurchaseCommandResponse.FromError(ResponseCodes.Conflict);
            }

            var result = await _storeService.PurchaseAsync(user, collection, cancellationToken);
            return result.Success ? PurchaseCommandResponse.SuccessResponse : PurchaseCommandResponse.FromError(result.ErrorMessage);
        }
    }
}