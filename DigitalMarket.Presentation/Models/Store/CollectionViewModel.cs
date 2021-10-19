using DigitalMarket.BisunessLogic.Models;

namespace DigitalMarket.Presentation.Models.Store
{
    public record CollectionViewModel
    {
        public Collection Collection { get; init; }
        public Item[] Items { get; init; }
    }
}
