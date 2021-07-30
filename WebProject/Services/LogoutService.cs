using DataModel.Models;
using Microsoft.AspNetCore.Identity;
using WebProject.Interfaces;

namespace WebProject.Services {
    public class LogoutService : ILogout {

        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutService(SignInManager<ApplicationUser> signInManager) {
            _signInManager = signInManager;
        }

        public void LogoutUser() {
            _signInManager.SignOutAsync();
        }
    }
}
