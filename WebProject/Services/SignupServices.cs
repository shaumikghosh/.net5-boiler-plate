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
    public class SignupServices : ISignup {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DatabaseContext _databaseContext;

        public SignupServices(UserManager<ApplicationUser> userManager, DatabaseContext databaseContext) {
            _userManager = userManager;
            _databaseContext = databaseContext;
        }

        public async Task<string> SignUp(SignupModel signupModel) {

            var dateTime = DateTime.Now;
            var user = new ApplicationUser {
                FirstName = signupModel.FirstName,
                LastName = signupModel.LastName,
                Name = signupModel.Name.ToLower().Trim(),
                UserName = signupModel.Email,
                NormalizedUserName = signupModel.Email,
                Email = signupModel.Email,
                EmailConfirmed = false,
                PhoneNumberConfirmed = true,
                CreatedAt = dateTime.Date,
            };


            var userCheck = await _userManager.FindByEmailAsync(signupModel.Email);
            var userUsername = _userManager.Users.Where(x => x.Name == signupModel.Name).FirstOrDefault();

            if (userCheck == null) {
                if (userUsername == null) {
                    var result = await _userManager.CreateAsync(user, signupModel.Password);
                    await _userManager.SetLockoutEnabledAsync(user, false);
                    if (result.Succeeded) {
                        var token = new VerificationTokens {
                            Token = EmailVerificationToken(50, user.Id),
                            Used = false,
                            CreatedAt = dateTime,
                            User = user
                        };
                        await _databaseContext.Tokens.AddAsync(token);
                        await _userManager.AddToRoleAsync(user, "User");
                        var ai = new UserAdditionalInfo {
                            UserId = user.Id
                        };
                        await _databaseContext.AdditionalInfos.AddAsync(ai);
                        await _databaseContext.SaveChangesAsync();
                        return "RegistrationCompleted";
                    }
                } else {
                    return "UsernameInUse";
                }
            } else {
                return "EmailInUse";
            }
            return null;
        }

        private string EmailVerificationToken(int length, string id) {
            var str_build = new StringBuilder();
            var random = new Random();

            char letter;

            for (int i = 0; i < length; i++) {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            var username = _userManager.Users.Where(x => x.Id == id).Include(toke => toke.Tokens).FirstOrDefault();

            if (username == null) {
                return str_build.ToString().ToLower();
            } else {
                return EmailVerificationToken(50, null);
            }
        }
    }
}
