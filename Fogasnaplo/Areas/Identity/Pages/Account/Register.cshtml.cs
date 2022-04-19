using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Fogasnaplo.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "A mező kitöltése kötelező!")]
            [Display(Name = "Vezetéknév")]
            public string VezetekNev { get; set; }

            [Required(ErrorMessage = "A mező kitöltése kötelező!")]
            [Display(Name = "Keresztnév")]
            public string KeresztNev { get; set; }

            [Required(ErrorMessage = "A mező kitöltése kötelező!")]
            [Display(Name = "Horgászigazolvány száma")]

            public string HorgaszIgazolvany { get; set; }

            [Required(ErrorMessage = "A mező kitöltése kötelező!")]
            [Display(Name = "Csapatnév")]
            public string Csapatnev { get; set; }


            [Required(ErrorMessage = "A mező kitöltése kötelező!")]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Required(ErrorMessage = "A mező kitöltése kötelező!")]
            [StringLength(100, ErrorMessage = "A {0} legalább {2} és legfeljebb {1} karakter hosszú lehet.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Jelszó")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Jelszó megerősítése")]
            [Compare("Password", ErrorMessage = "A jelszavak nem egyeznek.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Models.Users { UserName = Input.Email, Email = Input.Email, VezetekNev = Input.VezetekNev, KeresztNev = Input.KeresztNev, Csapatnev = Input.Csapatnev, HorgaszIgazolvany = Input.HorgaszIgazolvany };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Az új profil létrehozásra került.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "E-mail jóváhagyása",
                        $"A profil megerősítéséhez <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>kattints ide</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
