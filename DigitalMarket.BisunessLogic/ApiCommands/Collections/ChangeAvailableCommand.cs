using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.BisunessLogic.ApiCommands.Collections
{
    public record ChangeAvailableCommand : IRequest<ChangeAvailableResponse>
    {
        [Required]
        public Guid Id { get; init; }
        
        [Required]
        public bool Available { get; init; }
    }
}