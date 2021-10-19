using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public record CreateItemCommand : IRequest<CreateItemResponse>
    {
        public string MarketName { get; init; }
        public string ImageUrl { get; init; }
        public string Description { get; init; }
        public Guid CollectionId { get; init; }
        public Guid RarityId { get; init; }
        public double DropChance { get; init; }
    }
}
