using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public record UpdateItemCommand : IRequest<UpdateItemResponse>
    {
        public Guid Id { get; init; }
        public string MarketName { get; init; }
        public string Description { get; init; }
        public Guid RarityId { get; init; }
        public Guid CollectionId { get; init; }
    }
}
