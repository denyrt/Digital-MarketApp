using MediatR;

namespace DigitalMarket.BisunessLogic.Queries.Items
{
    public record GetItemsQuery : IRequest<GetItemsResponse>
    {
    }
}
