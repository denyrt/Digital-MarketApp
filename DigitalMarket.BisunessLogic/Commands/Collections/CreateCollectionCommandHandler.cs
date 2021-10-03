using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, CreateCollectionResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public CreateCollectionCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<CreateCollectionResponse> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
        {
            var collection = new DigitalCollection
            {
                Name = request.Name,
                Description = request.Description
            };

            var create = await _digitalMarketDbContext.DigitalCollections.AddAsync(collection, cancellationToken);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return CreateCollectionResponse.FromSuccess(create.Entity);
        }
    }
}
