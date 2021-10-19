using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public record UpdateCollectionCommand : IRequest<UpdateCollectionResponse>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string ImageUrl { get; init; }
        public double Price { get; init; }
        public string Description { get; init; }
    }
}
