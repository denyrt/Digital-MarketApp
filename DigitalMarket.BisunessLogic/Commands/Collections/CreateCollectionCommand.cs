using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public record CreateCollectionCommand : IRequest<CreateCollectionResponse>
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
