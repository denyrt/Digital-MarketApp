using DigitalMarket.Application.Models;
using DigitalMarket.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalMarket.Application.Interfaces
{
    public interface  IStoreService
    {
        Task<PurchaseResult> PurchaseAsync(DigitalUser buyer, DigitalCollection collection, CancellationToken cancellationToken);
    }
}
