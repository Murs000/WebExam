using Microsoft.AspNetCore.Mvc;
using WebExamMVC.Models;
using WebExamMVC.Services;

namespace WebExamMVC.Controllers
{
    public class SubjectController(SubjectService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var subjects = await service.Get();
            return View(subjects);
        }
        public IActionResult Create()
        {
            return View("Form");
        }

        public async Task<IActionResult> Update(int id)
        {
            SubjectModel subject = await service.Get(id);
            return View("Form", subject);
        }
        public async Task<IActionResult> Insert(SubjectModel subject)
        {
            if (subject.Id == 0)
            {
                await service.Create(subject);
            }
            else
            {
                await service.Update(subject);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var exam = await service.Get(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }
        public IActionResult DeleteConfirmed(int id)
        {
            if (service.Delete(id).Result)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Delete), id);
        }
    }
}
