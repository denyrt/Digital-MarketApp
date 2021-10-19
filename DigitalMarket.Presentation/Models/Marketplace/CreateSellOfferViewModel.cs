using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Presentation.Models.Marketplace
{
    public record CreateSellOfferViewModel
    {
        [Required]
        public Guid InstanceId { get; init; }

        [Required]
        [Range(1d, double.MaxValue)]
        public double Price { get; init; }
    }
}
