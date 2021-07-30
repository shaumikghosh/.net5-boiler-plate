using DataModel.Models;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Interfaces;

namespace WebProject.Services {
    public class ForgetPasswordService : IForgetPassword {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DatabaseContext _databaseContext;

        public ForgetPasswordService(UserManager<ApplicationUser> userManager, DatabaseContext databaseContext) {
            _userManager = userManager;
            _databaseContext = databaseContext;
        }

        public async Task<string> ForgetPasswordEmail(ForgetPasswordEmail model) {
            var dateTime = DateTime.Now;
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null) {
                var vtoken = new VerificationTokens {
                    Token = EmailVerificationToken(50, model.Email),
                    Used = false,
                    CreatedAt = dateTime,
                    User = user
                };
                _databaseContext.Tokens.Add(vtoken);
                await _databaseContext.SaveChangesAsync();

                return vtoken.Token;
            } else {
                return "NotFoundUser";
            }
        }

        public async Task<bool> CheckToken(string token) {
            var returnToken = await _databaseContext.Tokens.Where(x => x.Token == token && x.Used == false).FirstOrDefaultAsync();
            if (returnToken == null) {
                return true;
            }
            return false;
        }

        public async Task<string> ResetPassword(string token, ChangeForgotPassword model) {
            var returnToken = await _databaseContext.Tokens.Where(x => x.Token == token).FirstOrDefaultAsync();
            if (returnToken == null) {
                return "InvalidTokenError";
            } else {
                var usertoken = await _databaseContext.Tokens.Where(x => x.Token == token).Include(x => x.User).FirstOrDefaultAsync();
                var user = await _userManager.Users.Where(x => x.Id == usertoken.User.Id).FirstOrDefaultAsync();
                var hasher = new PasswordHasher<ApplicationUser>();

                user.PasswordHash = hasher.HashPassword(null, model.Password);
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded) {
                    returnToken.Used = true;
                    _databaseContext.SaveChanges();
                    return "PasswordResetSuccess";
                }
            }
            return null;
        }

        private string EmailVerificationToken(int length, string email) {
            var str_build = new StringBuilder();
            var random = new Random();

            char letter;

            for (int i = 0; i < length; i++) {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            var username = _userManager.Users.Where(x => x.Email == email).Include(toke => toke.Tokens).FirstOrDefault();

            if (username == null) {
                return str_build.ToString().ToLower(); ;
            } else {
                return EmailVerificationToken(50, null);
            }
        }
    }
}
