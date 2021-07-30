using DataModel.Models;
using Microsoft.AspNetCore.Identity;
using WebProject.Areas.Admin.Interfaces;

namespace WebProject.Areas.Admin.Services {
    public class AdminLogoutService : IAdminLogout {

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminLogoutService(SignInManager<ApplicationUser> signInManager) {
            _signInManager = signInManager;
        }

        public void LogoutUser() {
            _signInManager.SignOutAsync();
        }
    }
}
