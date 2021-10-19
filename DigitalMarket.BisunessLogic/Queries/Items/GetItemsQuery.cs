using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Items
{
    public record GetItemsQuery : IRequest<GetItemsResponse>
    {
        public int PageOffset { get; init; }
        public int CountInPage { get; init; }
        public Guid? CollectionId { get; init; }
    }
}
