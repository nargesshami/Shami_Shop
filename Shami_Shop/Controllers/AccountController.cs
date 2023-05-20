using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Shami_Shop.Models;
using System.Security.Claims;
using Shami_Shop.Data.Repositories;

namespace Shami_Shop.Controllers
{
    public class AccountController: Controller
    {
        private IuserRepositories _userRepository;

        public AccountController(IuserRepositories userRepository)
        {
            _userRepository = userRepository;
        }

        #region Register

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            //if (_userRepository.IsExistUserByEmail(register.Email.ToLower()))
            //{
            //    ModelState.AddModelError("Email","ایمیل وارد شده قبلا ثبت نام کرده است");
            //    return View(register);
            //}

            Users user = new Users()
            {
                MobilePhone = register.MobilePhone.ToString(),
                Password = register.Password.ToString(),
                IsAdmin = false
            };

            _userRepository.AddUser(user);
            
            return View("SuccessRegister", register);
        }

        public IActionResult VerifyEmail(string mobile)
        {
            if (_userRepository.IsExistUserByMobile(mobile.ToString()))
            {
                return Json($"موبایل {mobile} تکراری است");
            }

            return Json(true);
        }
        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userRepository.GetUserForLogin(login.MobilePhone.ToString(), login.Password.ToString());
            if (user == null)
            {
                ModelState.AddModelError("MobilePhone", "اطلاعات صحیح نیست");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.MobilePhone),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
                // new Claim("CodeMeli", user.Email),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }

        #endregion

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Account/Login");
        }

    }
}
