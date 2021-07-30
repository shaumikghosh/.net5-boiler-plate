using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebProject.Areas.Admin.Customs;
using WebProject.Areas.Admin.Interfaces;

namespace WebProject.Areas.Admin.Controllers {
    [Area("Admin")]
    [Route("admin")]

    [ServerAuthorize]
    public class DashboardController : Controller {

        private readonly IUserService _userService;

        public DashboardController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        [Route("dashboard")]
        public async Task<IActionResult> Dashboard() {
            var users = await _userService.GetAll();
            return View(users);
        }
    }
}
