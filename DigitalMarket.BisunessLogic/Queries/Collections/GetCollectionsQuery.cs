using MediatR;

namespace DigitalMarket.BisunessLogic.Queries.Collections
{
    public record GetCollectionsQuery : IRequest<GetCollectionsResponse>
    {
        public bool OnlyAvailable { get; init; }
    }
}
