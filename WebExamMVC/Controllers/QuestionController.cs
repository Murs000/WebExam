using Microsoft.AspNetCore.Mvc;
using WebExamMVC.Models;
using System.Linq;
using WebExamMVC.Services;
using WebExamMVC.ViewModels;

namespace WebExamMVC.Controllers
{
    public class QuestionController (SubjectService subjectService,QuestionService questionService) : Controller
    {
        public IActionResult Index()
        {
            var questions = questionService.Get().Result;
            return View(questions);
        }
        public IActionResult Create()
        {
            var model = new QuestionViewModel
            {
                Subjects = subjectService.Get().Result // Fetch available subjects from the database
            };
            return View("Form",model);
        }

        [HttpPost]
        public IActionResult Insert(QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    // Save the question
                    QuestionModel question = new QuestionModel
                    {
                        Condition = model.Condition,
                        SubjectId = model.SubjectId,
                        Subject = subjectService.Get(model.SubjectId).Result

                    };

                    foreach (var choice in model.Choises)
                    {
                        question.Choises.Add(choice);
                    }

                    // Set the correct choice
                    if (model.CorrectChoiceIndex >= 0 && model.CorrectChoiceIndex < model.Choises.Count)
                    {
                        question.Choises[model.CorrectChoiceIndex].IsTrue = true;
                    }
                    questionService.Create(question);
                }
                else
                {
                    // Save the question
                    QuestionModel question = new QuestionModel
                    {
                        Id = model.Id,
                        Condition = model.Condition,
                        SubjectId = model.SubjectId,
                        Subject = subjectService.Get(model.SubjectId).Result

                    };

                    foreach (var choice in model.Choises)
                    {
                        question.Choises.Add(choice);
                    }

                    // Set the correct choice
                    if (model.CorrectChoiceIndex >= 0 && model.CorrectChoiceIndex < model.Choises.Count)
                    {
                        question.Choises[model.CorrectChoiceIndex].IsTrue = true;
                    }
                    questionService.Update(question);
                }

                return RedirectToAction(nameof(Index));
            }
            model.Subjects = subjectService.Get().Result; // Re-populate subjects if validation fails
            return View("Form", model);
        }

        public async Task<IActionResult> Update(int id)
        {
            QuestionModel question = await questionService.Get(id);

            QuestionViewModel questionViewModel = new QuestionViewModel
            {
                Id = question.Id,
                Condition = question.Condition,
                Choises = question.Choises,
                CorrectChoiceIndex = question.Choises.IndexOf(question.Choises.Find(c => c.IsTrue == true)),
                SubjectId = question.SubjectId,
                Subject = question.Subject,
                Subjects = subjectService.Get().Result
            };

            return View("Form", questionViewModel);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await questionService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
