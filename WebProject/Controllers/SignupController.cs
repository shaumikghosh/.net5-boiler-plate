using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DataModel.ViewModels;
using WebProject.Interfaces;

namespace WebProject.Controllers.Clientside {
    public class SignupController : Controller {

        private readonly ISignup _signup;

        public SignupController(ISignup signup) {
            _signup = signup;
        }

        [HttpGet]
        [Route("/user/signup")]
        public IActionResult Signup() {
            var signupModel = new SignupModel();
            return View(signupModel);
        }

        [HttpPost]
        [Route("/user/signup")]
        public async Task<IActionResult> Signup(SignupModel signupModel) {
            if (ModelState.IsValid) {
                var result = await _signup.SignUp(signupModel);
                if (result is not null) {
                    if (result == "UsernameInUse") {
                        TempData["UsernameInUse"] = "Username already in use!";
                        return View(signupModel);
                    } else if (result == "EmailInUse") {
                        TempData["EmailInUse"] = "E-Mail already in use!";
                        return View(signupModel);
                    } else {
                        if (result == "RegistrationCompleted") {
                            TempData["RegistrationCompleteMessage"] = "Registration completed successfully, You can login now.";
                            return RedirectToAction("UserLogin", "Login");
                        }
                    }
                }
            }
            return View(signupModel);
        }
    }
}
