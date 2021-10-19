using DigitalMarket.BisunessLogic.Commands.Collections;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Admin
{
    public record CreateCollectionViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; init; }

        [Required]
        [Url]
        public string ImageUrl { get; init; }
        
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; init; }
        
        [Required]
        [Range(1d, double.MaxValue)]
        public double Price { get; init; }
    }

    public static class CreateCollectionViewModelMapping
    {
        public static CreateCollectionCommand ToCommand(this CreateCollectionViewModel createCollectionViewModel)
        {
            return new()
            {
                Name = createCollectionViewModel.Name,
                ImageUrl = createCollectionViewModel.ImageUrl,
                Description = createCollectionViewModel.Description,
                Price = createCollectionViewModel.Price,
                Available = false
            };
        }
    }
}
