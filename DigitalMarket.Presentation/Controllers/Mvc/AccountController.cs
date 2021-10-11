using DigitalMarket.BisunessLogic.Commands.Email;
using DigitalMarket.BisunessLogic.Commands.Account;
using DigitalMarket.Domain.Constants;
using DigitalMarket.Presentation.Models.Account;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalMarket.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizerFactory _stringLocalizerFactory;

        public AccountController(IMediator mediator, IStringLocalizerFactory stringLocalizerFactory)
        {
            _mediator = mediator;
            _stringLocalizerFactory = stringLocalizerFactory;
        }

        [HttpGet("Login")]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginModel, [FromQuery] string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            LoginResponse response = await _mediator.Send(loginModel.ToCommand());

            if (response.Success)
            {
                return LocalRedirect(returnUrl ?? "~/Home/Index");
            }

            if (response.Code == ResponseCodes.EmailNotConfirmed)
            {
                ViewBag.RequiresEmailConfirmation = true;
                return View();
            }


            IStringLocalizer localizer = _stringLocalizerFactory.Create("Models.LoginModel", GetType().Assembly.FullName);

            ModelState.AddModelError(nameof(LoginViewModel.Username), localizer["InvalidCredentials"]);
            ModelState.AddModelError(nameof(LoginViewModel.Password), localizer["InvalidCredentials"]);

            return View(loginModel);
        }

        [HttpGet("Registry")]
        public IActionResult Registry()
        {
            return View();
        }

        [HttpPost("Registry")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registry([FromForm] RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            RegistryResponse response = await _mediator.Send(registerModel.ToCommand());

            if (response.Success)
            {
                ViewBag.RequiresEmailConfirmation = true;
                return View();
            }

            IStringLocalizer localizer = _stringLocalizerFactory.Create("Models.RegisterModel", GetType().Assembly.FullName);
            IdentityErrorDescriber describer = new IdentityErrorDescriber();
            HashSet<string> errorCodes = response.ErrorCodes;

            if (errorCodes.Contains(describer.DuplicateUserName(string.Empty).Code))
            {
                ModelState.AddModelError(nameof(RegisterViewModel.Email), localizer["ValidationDuplicateEmail"].Value);
            }

            if (errorCodes.Contains(describer.DuplicateUserName(string.Empty).Code))
            {
                ModelState.AddModelError(nameof(RegisterViewModel.Username), localizer["ValidationDuplicateUsername"]);
            }

            if (errorCodes.Contains(describer.PasswordRequiresDigit().Code))
            {
                ModelState.AddModelError(nameof(RegisterViewModel.Password), localizer["ValidationPasswordRequiresDigit"]);
            }

            if (errorCodes.Contains(describer.PasswordRequiresNonAlphanumeric().Code))
            {
                ModelState.AddModelError(nameof(RegisterViewModel.Password), localizer["ValidationPasswordRequiresNonAlphanumeric"]);
            }

            if (errorCodes.Contains(describer.PasswordRequiresUpper().Code))
            {
                ModelState.AddModelError(nameof(RegisterViewModel.Password), localizer["ValidationPasswordRequiresUpper"]);
            }

            return View(registerModel);
        }


        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string username, [FromQuery] string token)
        {
            var command = new ConfirmEmailCommand
            {
                Username = username,
                Token = token
            };

            ViewBag.Confirmed = await _mediator.Send(command);
            return View();
        }

        [HttpGet("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("ForgotPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordViewModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordModel);
            }

            ViewBag.EmailSent = await _mediator.Send(forgotPasswordModel.ToCommand());
            return View(forgotPasswordModel);
        }

        [HttpGet("ResetPassword")]
        public IActionResult ResetPassword([FromQuery] string email, [FromQuery] string token)
        {
            return View(new ResetPasswordViewModel { Email = email, Token = token });
        }

        [HttpPost("ResetPassword")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordViewModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordModel);
            }

            ResetPasswordResponse resetPassword = await _mediator.Send(resetPasswordModel.ToCommand());

            if (resetPassword.Success)
            {
                return RedirectToAction(nameof(Login));
            }

            IStringLocalizer localizer = _stringLocalizerFactory.Create("Models.RegisterModel", GetType().Assembly.FullName);
            IdentityErrorDescriber describer = new IdentityErrorDescriber();
            HashSet<string> errorCodes = resetPassword.ErrorCodes;

            if (errorCodes.Contains(describer.PasswordRequiresDigit().Code))
            {
                ModelState.AddModelError(nameof(ResetPasswordViewModel.Password), localizer["PasswordRequiresDigit"]);
            }

            if (errorCodes.Contains(describer.PasswordRequiresNonAlphanumeric().Code))
            {
                ModelState.AddModelError(nameof(ResetPasswordViewModel.Password), localizer["PasswordRequiresNonAlphanumeric"]);
            }

            if (errorCodes.Contains(describer.PasswordRequiresUpper().Code))
            {
                ModelState.AddModelError(nameof(ResetPasswordViewModel.Password), localizer["PasswordRequiresUpper"]);
            }

            if (errorCodes.Contains(describer.InvalidToken().Code))
            {
                ModelState.AddModelError(nameof(ResetPasswordViewModel.Token), localizer["InvalidToken"]);
            }

            return View(resetPassword);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromQuery] string returnUrl)
        {
            await _mediator.Send(new SignOutCommand());
            return Redirect("~/Home/Index");
        }
    }
}
