using DigitalMarket.BisunessLogic.Commands.Collections;
using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Admin
{
    public record EditCollectionViewModel
    {
        [Required]
        public Guid Id { get; init; }
        
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

    public static class EditCollectionViewModelMapping
    {
        public static UpdateCollectionCommand ToCommand(this EditCollectionViewModel viewModel)
        {
            return new()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ImageUrl = viewModel.ImageUrl,
                Price = viewModel.Price,
                Description = viewModel.Description
            };
        }
    }
}
