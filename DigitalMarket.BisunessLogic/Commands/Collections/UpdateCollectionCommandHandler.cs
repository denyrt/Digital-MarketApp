using DigitalMarket.Data.Contexts;
using DigitalMarket.Domain.Constants;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public class UpdateCollectionCommandHandler : IRequestHandler<UpdateCollectionCommand, UpdateCollectionResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public UpdateCollectionCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<UpdateCollectionResponse> Handle(UpdateCollectionCommand request, CancellationToken cancellationToken)
        {
            var keyValues = new object[] { request.Id };
            var collection = await _digitalMarketDbContext.DigitalCollections.FindAsync(keyValues, cancellationToken);
            if (collection == null)
            {
                return UpdateCollectionResponse.FromError(ResponseCodes.NotFound);
            }

            collection.Name = request.Name;
            collection.Description = request.Description;

            _digitalMarketDbContext.DigitalCollections.Update(collection);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return UpdateCollectionResponse.SuccessResponse;
        }
    }
}
