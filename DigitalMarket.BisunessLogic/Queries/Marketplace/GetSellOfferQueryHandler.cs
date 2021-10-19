using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.BisunessLogic.Queries.Marketplace
{
    public class GetSellOfferQueryHandler : IRequestHandler<GetSellOfferQuery, GetSellOfferResponse>
    {
        public Task<GetSellOfferResponse> Handle(GetSellOfferQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
