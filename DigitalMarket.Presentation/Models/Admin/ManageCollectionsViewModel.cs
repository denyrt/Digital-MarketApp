using DigitalMarket.BisunessLogic.Models;

namespace DigitalMarket.Presentation.Models.Admin
{
    public record ManageCollectionsViewModel
    {
        public Collection[] Collections { get; init; }
    }
}