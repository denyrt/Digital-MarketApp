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
using Microsoft.AspNetCore.Authorization;
using DigitalMarket.Data.Models;
using System.Linq;
using DigitalMarket.BisunessLogic.Queries.Transactions;
using System;

namespace DigitalMarket.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizerFactory _stringLocalizerFactory;
        private readonly SignInManager<DigitalUser> _signInManager;

        public AccountController(
            IMediator mediator, 
            IStringLocalizerFactory stringLocalizerFactory,
            SignInManager<DigitalUser> signInManager)
        {
            _mediator = mediator;
            _stringLocalizerFactory = stringLocalizerFactory;
            _signInManager = signInManager;
        }

        [HttpGet("Me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var user = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name);
            var lastTransactions = await _mediator.Send(new GetTransactionsQuery
            {
                UserId = user.Id,
                CountInPage = 5,
                PageOffset = 0
            });

            static TransactionType GetTransactionType(Guid userId, Guid fromUserId, Guid toUserId)
            {
                if (fromUserId == toUserId) return TransactionType.Drop;
                if (userId == fromUserId) return TransactionType.Sell;
                if (userId == toUserId) return TransactionType.Bought;
                return TransactionType.None;
            }

            var model = new MeViewModel
            {
                Username = user.UserName,
                Email = "example@email.com", //user.Email,
                Balance = user.Balance,
                LastTransactions = lastTransactions.Transactions.Select(x => new MyTransactionViewModel
                {
                    Id = x.Id,
                    FromUser = x.FromUserId,
                    ToUser = x.ToUserId,
                    Payment = x.Payment,
                    TransactionType = GetTransactionType(user.Id, x.FromUserId, x.ToUserId),
                    InstanceId = x.InstanceId,
                    CreateDateUtc = x.CreateDateUtc
                }).ToArray()
            };

            return View(model);
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

            ViewBag.InvalidCredentials = true;
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

            DigitalUser user = registerModel.ToDigitalUser();
            IdentityResult identityResult = await _signInManager.UserManager.CreateAsync(user, registerModel.Password);

            if (identityResult.Succeeded)
            {
                if (await _mediator.Send(new SendConfirmEmailLetterCommand { DigitalUser = user }))
                {
                    ViewBag.RequiresEmailConfirmation = true;
                    return View();
                }
                else
                {
                    await _signInManager.UserManager.DeleteAsync(user);
                    ViewBag.RegistryFailed = true;
                    return View(registerModel);
                }
            }

            HashSet<string> errorCodes = identityResult.Errors.Select(x => x.Code).ToHashSet();
            IdentityErrorDescriber describer = new IdentityErrorDescriber();
            IStringLocalizer localizer = _stringLocalizerFactory.Create("Models.RegisterViewModel", GetType().Assembly.FullName);

            if (errorCodes.Contains(describer.DuplicateEmail(string.Empty).Code))
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

        [HttpGet("ChangePassword")]
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }
        
        [HttpPost("ChangePassword")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordViewModel changePasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(changePasswordViewModel);
            }

            var currentUser = await _signInManager.UserManager.FindByNameAsync(User.Identity.Name);
            var result = await _signInManager.UserManager.ChangePasswordAsync(currentUser, 
                changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);
            var errorDescriber = new IdentityErrorDescriber();
            
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                RedirectToAction(nameof(Login));
            }

            var errorCodes = result.Errors.Select(x => x.Code).ToHashSet();
            if (errorCodes.Contains(errorDescriber.PasswordMismatch().Code))
            {
                ModelState.AddModelError(nameof(ChangePasswordViewModel.CurrentPassword), "PasswordMismatch");
            }

            if (errorCodes.Contains(errorDescriber.PasswordRequiresDigit().Code))
            {
                ModelState.AddModelError(nameof(ChangePasswordViewModel.NewPassword), "PasswordRequiresDigit");
            }

            if (errorCodes.Contains(errorDescriber.PasswordRequiresUpper().Code))
            {
                ModelState.AddModelError(nameof(ChangePasswordViewModel.NewPassword), "PasswordRequiresUpper");
            }

            if (errorCodes.Contains(errorDescriber.PasswordRequiresNonAlphanumeric().Code))
            {
                ModelState.AddModelError(nameof(ChangePasswordViewModel.NewPassword), "PasswordRequiresNonAlphanumeric");
            }

            return View(changePasswordViewModel);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromQuery] string returnUrl)
        {
            await _mediator.Send(new SignOutCommand());
            return Redirect("~/Home/Index");
        }
    }
}
