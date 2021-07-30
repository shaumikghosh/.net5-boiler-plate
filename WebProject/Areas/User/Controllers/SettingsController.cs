using DataModel.Models;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebProject.Areas.User.Customs;
using WebProject.Areas.User.Interfaces;
using WebProject.Data;

namespace WebProject.Areas.User.Controllers {
    [Area("User")]
    [Route("user")]
    [ClientAuthorize]
    public class SettingsController : Controller {

        private readonly IProfileSettings _settings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly DatabaseContext _databaseContext;

        public SettingsController(IProfileSettings settings, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment, SignInManager<ApplicationUser> signInManager, DatabaseContext databaseContext) {
            _settings = settings;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
            _databaseContext = databaseContext;
        }

        [HttpGet, Route("settings")]
        public async Task<IActionResult> UserSettings() {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user_data = await _userManager.Users.Where(user => user.Id == id).Include(ai => ai.AdditionalInfos).FirstOrDefaultAsync();

            ViewBag.FirstName = user_data.FirstName;
            ViewBag.LastName = user_data.LastName;
            ViewBag.Username = user_data.Name;
            ViewBag.Website = user_data.AdditionalInfos.Website;
            ViewBag.BioData = user_data.AdditionalInfos.BioData;
            ViewBag.ProfileImage = user_data.AdditionalInfos.ProfileImage;

            return View();
        }

        [HttpPost, Route("settings")]
        public async Task<IActionResult> UserSettings(IFormCollection form) {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user_data = await _userManager.Users.Where(user => user.Id == id).Include(ai => ai.AdditionalInfos).FirstOrDefaultAsync();

            ViewBag.FirstName = user_data.FirstName;
            ViewBag.LastName = user_data.LastName;
            ViewBag.Username = user_data.Name;
            ViewBag.Website = user_data.AdditionalInfos.Website;
            ViewBag.BioData = user_data.AdditionalInfos.BioData;
            ViewBag.ProfileImage = user_data.AdditionalInfos.ProfileImage;

            if (form["ProfileImage"] == "") {
                var ci = new ChangeProfileInfo {
                    FirstName = form["FirstName"],
                    LastName = form["LastName"],
                    Username = form["UserName"]
                };

                var cai = new UserAdditionalInfo {
                    BioData = form["BioData"],
                    Website = form["Website"],
                };
                user_data.FirstName = ci.FirstName;
                user_data.LastName = ci.LastName;
                user_data.Name = ci.Username;
                await _userManager.UpdateAsync(user_data);

                var adinfo = await _databaseContext.AdditionalInfos.FindAsync(id);
                adinfo.BioData = cai.BioData;
                adinfo.Website = cai.Website;
                _databaseContext.AdditionalInfos.Update(adinfo);
                await _databaseContext.SaveChangesAsync();

                TempData["InfoUpdatedSuccess"] = "Your information is updated!";

                return RedirectToAction("UserSettings", "Settings", new { area = "User" });
            } else {
                var ci = new ChangeProfileInfo {
                    FirstName = form["FirstName"],
                    LastName = form["LastName"],
                    Username = form["UserName"]
                };
                user_data.FirstName = ci.FirstName;
                user_data.LastName = ci.LastName;
                user_data.Name = ci.Username;
                await _userManager.UpdateAsync(user_data);

                foreach (var file in form.Files) {
                    var cai = new UserAdditionalInfo {
                        BioData = form["BioData"],
                        Website = form["Website"],
                        ProfileImage = UploadedFile(file)
                    };

                    var adinfo = await _databaseContext.AdditionalInfos.FindAsync(id);
                    adinfo.BioData = cai.BioData;
                    adinfo.Website = cai.Website;
                    adinfo.ProfileImage = cai.ProfileImage;
                    _databaseContext.AdditionalInfos.Update(adinfo);
                    await _databaseContext.SaveChangesAsync();
                }

                TempData["InfoUpdatedSuccess"] = "Your information is updated!";

                return RedirectToAction("UserSettings", "Settings", new { area = "User" });
            }
        }

        private string UploadedFile(IFormFile model) {
            string uniqueFileName = null;

            if (model.FileName != null) {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "clientside/img/profile/");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                    model.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        [HttpGet, Route("change-email")]
        public async Task<IActionResult> ChangeEmail() {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.Email = user.Email;
            return View("~/Areas/User/Views/Settings/UserSettings.cshtml");
        }

        /*
         * @ Form validation for change email
         */
        [HttpPost, Route("change-email"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeEmail(IFormCollection formValue) {
            if (CheckEmailValidation(formValue) == null) {
                var viewModel = new ChangeEmail {
                    Email = formValue["Email"]
                };
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _settings.ChangeEmail(viewModel, userId);
                if (result.Succeeded) {
                    TempData["ChangeEmailSuccess"] = "Email has been updated successfully!";
                    return RedirectToAction("ChangeEmail", "Settings", new { area = "User" });
                }
            }
            var user = await _userManager.GetUserAsync(User);
            ViewBag.Email = user.Email;

            return View("~/Areas/User/Views/Settings/UserSettings.cshtml");
        }

        public IActionResult CheckEmailValidation(IFormCollection formValue) {
            if (String.IsNullOrEmpty(formValue["Email"])) {
                TempData["EmailFieldNull"] = "Email is required!";
                return RedirectToAction("ChangeEmail", "Settings", new { area = "User" });
            } else {
                return null;
            }
        }

        [HttpGet, Route("change-password")]
        public IActionResult ChangePassword() {
            return View("~/Areas/User/Views/Settings/UserSettings.cshtml");
        }

        /*
         * UserSettings is a instance of chnage passowrd for user profile
         */
        [HttpPost, Route("change-password"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(IFormCollection values) {
            if (CheckformForChangePassword(values) == null) {
                var data = new ChangePassword() {
                    CurrentPassword = values["CurrentPassword"],
                    Password = values["NewPassword"],
                };
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _settings.ChnagePassword(data, userId);
                if (result.Succeeded) {
                    TempData["ChangePasswordSucceded"] = "Password has been changed successfully!";
                    return RedirectToAction("ChangePassword", "Settings", new { area = "User" });
                } else {
                    TempData["CurrentPasswordError"] = "Entered password is mismatched to exist password!";
                    return RedirectToAction("ChangePassword", "Settings", new { area = "User" });
                }
            }
            return View("~/Areas/User/Views/Settings/UserSettings.cshtml");
        }

        /*
         * @ Form validation for change password
         */
        private IActionResult CheckformForChangePassword(IFormCollection keyValues) {
            if (String.IsNullOrEmpty(keyValues["CurrentPassword"]) && String.IsNullOrEmpty(keyValues["NewPassword"]) && String.IsNullOrEmpty(keyValues["ConfirmPassword"])) {
                TempData["AllFieldRequired_1"] = "All field is required!";
                return RedirectToAction("ChangePassword", "Settings", new { area = "User" });
            } else if (String.IsNullOrEmpty(keyValues["CurrentPassword"])) {
                TempData["CurrentPasswordEmpty"] = "Current password is required!";
                return RedirectToAction("ChangePassword", "Settings", new { area = "User" });
            } else if (String.IsNullOrEmpty(keyValues["NewPassword"])) {
                TempData["NewPasswordError"] = "New password is required!";
                return RedirectToAction("UserSettChangePasswordings", "Settings", new { area = "User" });
            } else if (keyValues["NewPassword"] != keyValues["ConfirmPassword"]) {
                TempData["PasswordVerificationError"] = "Password confirmation was failed!";
                return RedirectToAction("ChangePassword", "Settings", new { area = "User" });
            } else {
                return null;
            }
        }

        [HttpGet, Route("/user/deactivation")]
        public IActionResult DeactivateUser() {
            return View("~/Areas/User/Views/Settings/UserSettings.cshtml");
        }

        [HttpGet, Route("/user/deactive/{id}")]
        public async Task<IActionResult> DeactivateUser(string id) {
            var user = await _userManager.FindByIdAsync(id);
            user.LockoutEnabled = true;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) {
                TempData["AccountDeactivated"] = "You are account is deactivated! You are not able to login to this account right now.";
                await _signInManager.SignOutAsync();
                return RedirectToAction("UserLogin", "Login");
            }
            return View("~/Areas/User/Views/Settings/UserSettings.cshtml");
        }
    }
}
