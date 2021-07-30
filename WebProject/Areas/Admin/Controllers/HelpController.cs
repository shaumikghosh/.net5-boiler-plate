using Microsoft.AspNetCore.Mvc;

namespace WebProject.Areas.Admin.Controllers {
    public class HelpController : Controller {
        public IActionResult UserHelps() {
            return View();
        }
    }
}
