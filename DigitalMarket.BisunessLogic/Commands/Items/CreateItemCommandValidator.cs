using FluentValidation;

namespace DigitalMarket.BisunessLogic.Commands.Items
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(x => x.MarketName)
                .Cascade(CascadeMode.Stop)
                .Length(1, 100).WithMessage("Message length must be from 1 to 100 symbols.")
                .NotEmpty().WithMessage("Name is empty.");
            
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(500).WithMessage("Description maximum length is 500 symbols.")
                .NotEmpty().WithMessage("Description is empty.");
            
            RuleFor(x => x.RarityId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Rarity id is empty.");
            
            RuleFor(x => x.CollectionId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Collection id is empty.");

            RuleFor(x => x.DropChance)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0d);
        }
    }
}
