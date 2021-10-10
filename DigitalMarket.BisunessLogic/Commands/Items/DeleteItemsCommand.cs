using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public record DeleteItemsCommand : IRequest<DeleteItemsResponse>
    {
        public Guid[] Ids { get; init; }
    }
}