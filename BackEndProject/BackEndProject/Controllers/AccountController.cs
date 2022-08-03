using BackEndProject.DAL;
using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.Service;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
       
        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager, SignInManager<AppUser> signInManager, IConfiguration config, AppDbContext context)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
            _signInManager = signInManager;
            _config = config;
            _context = context;
        }
        public IActionResult Index()
        {           
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("register", "account");
            }

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

            DateTime now = DateTime.Now;
            DateTime confirm = now.AddMinutes(1);

            AppUser user = new AppUser
            {
                FirstName = registrVM.FirstName,
                LastName = registrVM.LastName,
                UserName = registrVM.UserName,
                Email = registrVM.Email,
                UserCreateTime = now,
                ConfirmMailTime = confirm,
                
            };
            IdentityResult result = await _userManager.CreateAsync(user, registrVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registrVM);
            }
            await _userManager.AddToRoleAsync(user, UserRoles.SuperAdmin.ToString());

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string confirmation = Url.Action("ConfirmEmail", "Account", new
            {
                token,
                Email = registrVM.Email
            }, Request.Scheme);

            Helpers helper = new Helpers(_config.GetSection("ConfirmationParameter:Email").Value, _config.GetSection("ConfirmationParameter:Password").Value);
            var emailResult = helper.SendEmail(registrVM.Email, confirmation);
            if (!emailResult)
            {
                //return View(registrVM);
                return RedirectToAction("login", "account");
            }

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
            var roles = await _userManager.GetRolesAsync(appUser);
            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, true, true);


            TimeSpan time = appUser.ConfirmMailTime.ToUniversalTime() - DateTime.Now.ToUniversalTime();
            var time2 = TimeSpan.FromMinutes(time.TotalMinutes);
            int m = time2.Minutes;
            var s = time2.Seconds;
            foreach (var item in roles)
            {
                if (result.Succeeded)
                {
                    ViewBag.Role = item;
                    if (s <= 0 && appUser.EmailConfirmed == false)
                    {
                        await _signInManager.SignOutAsync();
                        await _userManager.DeleteAsync(appUser);
                        ModelState.AddModelError("", "Email Reset! You can use this email again!");
                        return View(loginVM);
                    }
                    else if (item.ToLower() == "ban")
                    {
                        await _signInManager.SignOutAsync();

                        TempData["Banned"] = "Hesabiniz banlanmisdir";
                        return View(loginVM);
                    }
                    else if (appUser.EmailConfirmed == true && item.ToLower() == "member")
                    {
                        await _signInManager.SignInAsync(appUser, true);
                        return RedirectToAction("Index", "home");
                    }
                    else if (item.ToLower().Contains("admin"))
                    {
                        await _signInManager.SignInAsync(appUser, true);
                        return RedirectToAction("index", "dashboard", new { area = "AdminPanel" });
                    }
                }
            }
            ViewBag.Failed = appUser.AccessFailedCount;
            ViewBag.Success = result.Succeeded;
            ViewBag.Email = appUser.EmailConfirmed;
            TempData["User Create Time"] = appUser.UserCreateTime;
            TempData["IsConfirmTime"] = appUser.ConfirmMailTime;
            TempData["QalanVaxt"] = $"{m} deq {s}san erzinde mailinizi tesdiqleyin";

            if (result.IsLockedOut)
            {
                TimeSpan timeSpan = appUser.LockoutEnd.Value.UtcDateTime.ToUniversalTime() - DateTime.Now.ToUniversalTime();
                var timeSpanFromMinutes = TimeSpan.FromMinutes(timeSpan.TotalMinutes);
                int mm = timeSpanFromMinutes.Minutes;
                int ss = timeSpanFromMinutes.Seconds;
                TempData["Error"] = $"{mm} deq {ss} saniye sonra daxil ola bilersiniz";
                return View(loginVM);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "email or  password is invalid!");
                return View(loginVM);
            }
            if (result == null)
            {
                ModelState.AddModelError("", "email or  password is invalid!");
                return View(loginVM);
            }

            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }

            return View();
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
