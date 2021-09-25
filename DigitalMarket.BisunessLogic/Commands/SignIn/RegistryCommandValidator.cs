using FluentValidation;

namespace DigitalMarket.BisunessLogic.Commands.SignIn
{
    public class RegistryCommandValidator : AbstractValidator<RegistryCommand>
    {
        public RegistryCommandValidator()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(1, 100);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(1, 100);
        }
    }
}