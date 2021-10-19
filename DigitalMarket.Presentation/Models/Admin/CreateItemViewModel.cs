using DigitalMarket.BisunessLogic.Commands.Items;
using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Admin
{
    public record CreateItemViewModel
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
        [Range(0d, 100d)]
        public double DropChance { get; init; }

        [Required]
        public Guid CollectionId { get; init; }

        [Required]
        public Guid RarityId { get; init; }
    }

    public static class CreateItemViewModelMapping
    {
        public static CreateItemCommand ToCommand(this CreateItemViewModel createItemViewModel)
        {
            return new()
            {
                MarketName = createItemViewModel.Name,
                ImageUrl = createItemViewModel.ImageUrl,
                Description = createItemViewModel.Description,
                DropChance = createItemViewModel.DropChance,
                RarityId = createItemViewModel.RarityId,
                CollectionId = createItemViewModel.CollectionId
            };
        }
    }
}
