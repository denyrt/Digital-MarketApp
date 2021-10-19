using DigitalMarket.BisunessLogic.Commands.Items;
using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Admin
{
    public record EditItemViewModel
    {
        [Required]
        public Guid Id { get; init; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string MarketName { get; init; }

        [Required]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(500)]
        public string Description { get; init; }

        [Required]
        [Range(0d, double.MaxValue)]
        public double DropChance { get; init; }

        [Required]
        public Guid CollectionId { get; init; }

        [Required]
        public Guid RarityId { get; init; }
    }

    public static class EditViewModelMapping
    {
        public static UpdateItemCommand ToCommand(this EditItemViewModel viewModel) 
        {
            return new()
            {
                Id = viewModel.Id,
                MarketName = viewModel.MarketName,
                Description = viewModel.Description,
                ImageUrl = viewModel.ImageUrl,
                DropChance = viewModel.DropChance,
                CollectionId = viewModel.CollectionId,
                RarityId = viewModel.RarityId
            };
        }
    }
}
