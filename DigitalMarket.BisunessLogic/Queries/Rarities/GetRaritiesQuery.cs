using MediatR;

namespace DigitalMarket.BisunessLogic.Queries.Rarities
{
    public record GetRaritiesQuery : IRequest<GetRaritiesResponse>
    {
        
    }
}