using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataModel.ViewModels;
using WebProject.Interfaces;

namespace WebProject.Controllers {
    public class LoginController : Controller {

        protected ILogin _login;

        public LoginController(ILogin login) {
            _login = login;
        }

        [HttpGet]
        [Route("/user/login")]
        public IActionResult UserLogin() {
            return View();
        }

        [HttpPost]
        [Route("/user/login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin(LoginModel loginModel, string url) {
            if (ModelState.IsValid) {
                var result = await _login.LogIn(loginModel);
                if (result is not null) {
                    if (result == "InvalidCredentialError") {
                        TempData["InvalidCredentialError"] = "Invalid credentials provided!";
                        return View();
                    }
                    if (result == "UserDeactivated") {
                        TempData["UserDeactivated"] = "You can not login due to inactive your account. Please contact to support for enabling your account again. Thanks.";
                    }
                    if (result == "User") {
                        HttpContext.Response.Cookies.Append("logedin", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
                        if (!string.IsNullOrEmpty(url)) {
                            return LocalRedirect(url);
                        } else {
                            return RedirectToAction("Profile", "Profile", new { area = "User" });
                        }
                    }
                }
            }
            return View();
        }
    }
}
