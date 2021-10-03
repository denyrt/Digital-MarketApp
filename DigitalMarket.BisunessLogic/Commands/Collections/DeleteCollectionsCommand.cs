using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Collections
{
    public record DeleteCollectionsCommand : IRequest<DeleteCollectionsResponse>
    {
        public Guid[] Ids { get; init; }
    }
}
