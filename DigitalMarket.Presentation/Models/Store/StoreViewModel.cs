using DigitalMarket.BisunessLogic.Models;

namespace DigitalMarket.Presentation.Models.Store
{
    public record StoreViewModel
    {
        public Collection[] Collections { get; init; }
    }
}