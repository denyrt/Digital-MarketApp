using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public record CreateCollectionCommand : IRequest<CreateCollectionResponse>
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public double Price { get; init; }
        public bool Available { get; init; }
    }
}
