using DataModel.Models;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebProject.Areas.Admin.Customs;
using WebProject.Areas.Admin.Interfaces;

namespace WebProject.Areas.Admin.Controllers {
    [Area("Admin")]
    [Route("admin")]
    [ServerAuthorize]
    public class UserController : Controller {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserService _userService;

        public UserController(
            RoleManager<ApplicationRole> roleManager,
            IUserService userService
        ) {
            _roleManager = roleManager;
            _userService = userService;
        }

        [HttpGet]
        [Route("all-users")]
        public async Task<IActionResult> AllUsers() {
            ViewBag.SuperAdmins = await _userService.GetSuperAdmins();
            return View();
        }

        [HttpGet]
        [Route("create-user")]
        public IActionResult CreateUser() {
            var createUser = new CreateUser();
            ViewBag.Roles = _roleManager.Roles;
            return View(createUser);
        }

        [HttpPost]
        [Route("create-user")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(CreateUser createUser) {
            ViewBag.Roles = _roleManager.Roles;
            if (ModelState.IsValid) {
                var result = await _userService.CreateUser(createUser);
                if (result is not null) {
                    if (result.GetType() is string && result == "EmailExist") {
                        TempData["EmailExist"] = "Email already in use!";
                        return View(createUser);
                    } else {
                        TempData["Email"] = result["email"];
                        TempData["Password"] = result["password"];
                        TempData["Role"] = result["Role"];
                        TempData["UserCreated201"] = result["UserCreated201"];
                        return RedirectToAction("CreateUser", "User", new { area = "Admin" });
                    }
                }
            }
            return View(createUser);
        }

        [HttpGet]
        [Route("admins")]
        public async Task<IActionResult> Admins() {
            ViewBag.Admins = await _userService.GetAdmins();
            return View();
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Users() {
            ViewBag.Users = await _userService.GetUsers();
            return View();
        }

        [HttpGet, Route("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(string id) {
            var result = await _userService.DeleteUser(id);
            if (result.Succeeded) {
                TempData["UserDeleteSuccess"] = "User is deleted successfully!";
                return RedirectToAction("AllUsers", "User", new { area = "Admin" });
            } else {
                if (result.Errors.Any()) {
                    TempData["UserDeleteFail"] = "Something was wrong, try again!";
                    return RedirectToAction("AllUsers", "User", new { area = "Admin" });
                }
            }
            return View();
        }

        [HttpGet, Route("edit-user/{id}")]
        public async Task<IActionResult> EditUser(string Id) {
            var result = await _userService.GetEditAbleUser(Id);
            ViewBag.Roles = _roleManager.Roles;
            if (result is not null) {
                return View(result);
            }
            return View();
        }

        [HttpPost, Route("edit-user/{id}")]
        public async Task<IActionResult> EditUser(string Id, UpdateUser updateUser) {
            ViewBag.Roles = _roleManager.Roles;
            if (ModelState.IsValid) {
                var result = await _userService.UpdateUser(Id, updateUser);
                if (result is not null) {
                    if (result == "IdValue") {
                        TempData["IdValue"] = "User Id has no value!";
                        return View(updateUser);
                    } else {
                        if (result == "UserUpdate201") {
                            TempData["UserUpdate201"] = "User data updated successfully!";
                            return RedirectToAction("EditUser", "User", new { area = "Admin" });
                        }
                    }
                }
            }
            return View(updateUser);
        }

        [HttpGet, Route("search-user")]
        public async Task<IActionResult> SearchUser(string data) {
            var searchUser = new SearchUser();
            ViewBag.SearchResult = await _userService.GetSearchedUser(data);
            return View(searchUser);
        }
    }
}
