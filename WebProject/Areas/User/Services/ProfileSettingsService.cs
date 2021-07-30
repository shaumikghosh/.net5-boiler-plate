using DataModel.Models;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Areas.User.Interfaces;

namespace WebProject.Areas.User.Services {
    public class ProfileSettingsService : IProfileSettings {
        private readonly UserManager<ApplicationUser> _userManager;
        public ProfileSettingsService(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<dynamic> ChnagePassword(ChangePassword change, string userId) {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ChangePasswordAsync(user, change.CurrentPassword, change.Password);
            return result;
        }

        public async Task<dynamic> ChangeEmail(ChangeEmail email, string userId) {
            var user = await _userManager.FindByIdAsync(userId);
            if (user.Email != email.Email) {
                user.Email = email.Email;
                user.NormalizedEmail = email.Email;
                user.UserName = email.Email;
                user.EmailConfirmed = false;
            } else {
                user.Email = user.Email;
                user.NormalizedEmail = user.Email;
            }
            return await _userManager.UpdateAsync(user);
        }

        public async Task<dynamic> ChangeProfileDetails(ChangeProfileDetails changeProfileDetails, string id) {
            var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();

            user.FirstName = changeProfileDetails.FirstName;
            user.LastName = changeProfileDetails.LastName;
            user.Email = changeProfileDetails.Email;
            user.UserName = changeProfileDetails.Email;
            user.NormalizedUserName = changeProfileDetails.Email;
            user.NormalizedEmail = changeProfileDetails.Email;

            return await _userManager.UpdateAsync(user);
        }
    }
}
