// File: Controllers/ExamController.cs
using Microsoft.AspNetCore.Mvc;
using WebExamMVC.Models;
using WebExamMVC.Services;
using WebExamMVC.ViewModels;

namespace WebExamMVC.Controllers
{
    public class ExamController(ExamService examService, SubjectService subjectService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var exams = await examService.Get();
            foreach (var exam in exams)
            {
                if(exam.Subject is null)
                {
                    exam.Subject = subjectService.Get(exam.SubjectId).Result;
                }
            }
            return View(exams);
        }

        public IActionResult Create()
        {
            ExamViewModel model = new ExamViewModel();
            model.Subjects = subjectService.Get().Result;
            return View("Form", model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var exam = await examService.Get(id);
            if (exam == null)
            {
                return NotFound();
            }
            ExamViewModel model = new ExamViewModel
            {
                Id = id,
                ExamStart = exam.ExamStart,
                ExamDuration = exam.ExamEnd.Hour - exam.ExamStart.Hour,
                Subject = exam.Subject,
                SubjectId = exam.SubjectId,
                Subjects = subjectService.Get().Result,
            };
            return View("Form", model);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ExamViewModel exam)
        {
            if (ModelState.IsValid)
            {
                ExamModel examModel = new ExamModel
                {
                    Id = exam.Id,
                    
                    Subject = subjectService.Get(exam.SubjectId).Result,
                    ExamStart = exam.ExamStart,
                    ExamEnd = exam.ExamStart.AddHours(exam.ExamDuration),
                    SubjectId = exam.SubjectId,

                };
                if(exam.Id == 0)
                {
                    await examService.Create(examModel);
                }
                else
                {
                    await examService.Update(examModel);
                }
                return RedirectToAction(nameof(Index));
            }
            return View("Form",exam);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var exam = await examService.Get(id);
            if (exam == null)
            {
                return NotFound();
            }
            exam.Subject = subjectService.Get(exam.SubjectId).Result;
            return View(exam);
        }

        public IActionResult DeleteConfirmed(int id)
        {
            if (examService.Delete(id).Result)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Delete),id);
        }
    }
}
