using Microsoft.AspNetCore.Mvc;
using WebExamMVC.Models;
using WebExamMVC.Services;

namespace WebExamMVC.Controllers
{
    public class UserController (UserService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await service.Get();
            return View(users);
        }
        public IActionResult Create()
        {
            return View("Form");
        }

        public async Task<IActionResult> Update(int id)
        {
            UserModel user = await service.Get(id);
            return View("Form", user);
        }
        public async Task<IActionResult> Insert(UserModel user)
        {
            //if (ModelState.IsValid)
            //{
                if(user.Id == 0)
                {
                    await service.Create(user);
                }
                else
                {
                    await service.Update(user);
                }
            //}
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await service.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
