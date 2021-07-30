using DataModel.Models;
using DataModel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Areas.Admin.Interfaces;

namespace WebProject.Areas.Admin.Services {
    public class UserService : IUserService{

        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        public async Task<dynamic> GetAll() {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<dynamic> GetSuperAdmins() {
            return await _userManager.GetUsersInRoleAsync("SuperAdmin");
        }

        public async Task<dynamic> GetAdmins() {
            return await _userManager.GetUsersInRoleAsync("Admin");
        }

        public async Task<dynamic> GetUsers() {
            return await _userManager.GetUsersInRoleAsync("User");
        }

        public async Task<dynamic> CreateUser(CreateUser createUser) {

            var dateTime = DateTime.Now;

            var user = new ApplicationUser {
                UserName = createUser.Email,
                NormalizedUserName = createUser.Email,
                Email = createUser.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = dateTime,
            };

            var userCheck = await _userManager.FindByEmailAsync(user.Email);

            if (userCheck == null) {
                var result = await _userManager.CreateAsync(user, createUser.Password);
                if (result.Succeeded) {
                    await _userManager.AddToRoleAsync(user, createUser.UserRole);
                    var data = new Hashtable() {
                        ["UserCreated201"] = "New user is created successfully!",
                        ["Email"] = createUser.Email,
                        ["Password"] = createUser.Password,
                        ["Role"] = createUser.UserRole
                    };
                    return data;
                }
            } else {
                return "EmailExist";
            }
            return null;
        }

        public async Task<dynamic> DeleteUser(string userId) {
            var user = _userManager.Users.Where(user => user.Id == userId).FirstOrDefault();
            return await _userManager.DeleteAsync(user);
        }

        public async Task<dynamic> GetEditAbleUser(string id) {
            var user = await _userManager.Users.Where(user => user.Id == id).Include(role => role.ApplicationUserRole).ThenInclude(role => role.ApplicationRole).FirstOrDefaultAsync();
            if (user != null) {
                var updateUser = new UpdateUser() {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserRole = user.ApplicationUserRole.Select(x=>x.ApplicationRole.Name).FirstOrDefault(),
                    UserEnablity = user.LockoutEnabled
                };
                return updateUser;
            }
            return null;
        }

        public async Task<dynamic> UpdateUser(string Id, UpdateUser updateUser) {
            var user = await _userManager.FindByIdAsync(Id);
            var currentRoles = await _userManager.GetRolesAsync(user);

            if (user != null) {
                var updatedUserData = new ApplicationUser() {
                    FirstName = updateUser.FirstName,
                    LastName = updateUser.LastName,
                    Email = updateUser.Email,
                    NormalizedEmail = updateUser.Email,
                    NormalizedUserName = updateUser.Email
                };
                var result = await _userManager.UpdateAsync(updatedUserData);

                if (result.Succeeded) {
                    await _userManager.RemoveFromRolesAsync(updatedUserData, currentRoles);
                    await _userManager.AddToRoleAsync(updatedUserData, updateUser.UserRole);
                    await _userManager.SetLockoutEnabledAsync(updatedUserData, updateUser.UserEnablity);
                    return "UserUpdate201";
                }
            } else {
                return "IdValue";
            }
            return null;
        }

        public async Task<dynamic> GetSearchedUser(string keyword) {
            return await _userManager.Users.Include(user => user.ApplicationUserRole).ThenInclude(role => role.ApplicationRole).Where(x => x.Email.Contains(keyword) || x.UserName.Contains(keyword) || x.FirstName.Contains(keyword) || x.LastName.Contains(keyword)).ToListAsync();
        }
    }
}
