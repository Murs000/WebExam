using Microsoft.AspNetCore.Mvc;

namespace WebExamMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
