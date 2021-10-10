using MediatR;

namespace DigitalMarket.BisunessLogic.Commands.Account
{
    public record SignOutCommand : IRequest<SignOutResponse>
    {
    }
}
