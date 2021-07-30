using DataModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebProject.Areas.User.Customs;
using WebProject.Data;

namespace WebProject.Areas.User.Controllers {
    [Area("User")]
    [Route("user")]
    [ClientAuthorize]
    public class ProfileController : Controller {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DatabaseContext _databaseContext;

        public ProfileController(UserManager<ApplicationUser> userManager, DatabaseContext databaseContext) {
            _userManager = userManager;
            _databaseContext = databaseContext;
        }

        [HttpGet, Route("profile")]
        public IActionResult Profile() {
            return View();
        }


        [HttpGet, Route("email/{token}")]
        public async Task<IActionResult> VerifyEmail(string token) {
            var useriD = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _databaseContext.Tokens.Where(x => x.Token == token && x.Used == false).FirstOrDefaultAsync();

            if (result != null) {
                result.Used = true;
                _databaseContext.SaveChanges();
                var user = await _userManager.FindByIdAsync(useriD);
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                TempData["EmailVerified"] = "Thanks for verifying your mail .... !";
            } else {
                TempData["TokenError"] = "You'r trying to use a wrong / used token .... !";
            }
            return View();
        }
    }
}
