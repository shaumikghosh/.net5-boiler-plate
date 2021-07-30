using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        [Route("/")]
        public IActionResult Index() {
            return View();
        }
    }
}
