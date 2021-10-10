using DigitalMarket.Data.Contexts;
using DigitalMarket.Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Commands.Rarities
{
    public class CreateRarityCommandHandler : IRequestHandler<CreateRarityCommand, CreateRarityResponse>
    {
        private readonly DigitalMarketDbContext _digitalMarketDbContext;

        public CreateRarityCommandHandler(DigitalMarketDbContext digitalMarketDbContext)
        {
            _digitalMarketDbContext = digitalMarketDbContext;
        }

        public async Task<CreateRarityResponse> Handle(CreateRarityCommand request, CancellationToken cancellationToken)
        {
            var rarity = new DigitalRarity
            {
                Name = request.Name
            };

            var create = await _digitalMarketDbContext.DigitalRarities.AddAsync(rarity, cancellationToken);
            await _digitalMarketDbContext.SaveChangesAsync(cancellationToken);
            return CreateRarityResponse.FromSuccess(create.Entity);
        }
    }
}
