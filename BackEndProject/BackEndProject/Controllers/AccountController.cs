using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BackEndProject.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signInManager;


        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registr()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Registr")]
        public async Task<IActionResult> Registr(RegistrVM registrVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser
            {
                FirstName = registrVM.FirstName,
                LastName = registrVM.LastName,
                UserName = registrVM.UserName,
                Email = registrVM.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, registrVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, true);
            await _userManager.AddToRoleAsync(user, UserRoles.SuperAdmin.ToString());
            return RedirectToAction("login", "account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM, string ReturnUrl)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.Email);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Istifadeci adi ve ya sifre yanlishdir");
                return View(loginVM);
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, true, true);

            if (result.IsLockedOut)
            {
                TimeSpan timeSpan = appUser.LockoutEnd.Value.UtcDateTime.ToUniversalTime() - DateTime.Now.ToUniversalTime();
                var timeSpanFromMinutes = TimeSpan.FromMinutes(timeSpan.TotalMinutes);
                int mm = timeSpanFromMinutes.Minutes;
                int ss = timeSpanFromMinutes.Seconds;
                TempData["Error"] = $"{mm} deq {ss} saniye sonra daxil ola bilersiniz";
                //ModelState.AddModelError("", "account bloklandir");
                return View(loginVM);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Istifadeci adi ve ya sifre yanlishdir");
                return View(loginVM);
            }
            var roles = await _userManager.GetRolesAsync(appUser);
            foreach (var item in roles)
            {
                if (item == "SuperAdmin")
                {
                    return RedirectToAction("index", "dashboard", new { area = "AdminPanel" });
                }
            }
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _rolemanager.RoleExistsAsync(item.ToString()))
                {
                    await _rolemanager.CreateAsync(new IdentityRole { Name = item.ToString() });
                }
            }
        }

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
    }
}
