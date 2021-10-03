using MediatR;
using System;

namespace DigitalMarket.BisunessLogic.Queries.Items
{
    public record GetItemQuery : IRequest<GetItemResponse>
    {
        public Guid Id { get; init; }
    }
}
