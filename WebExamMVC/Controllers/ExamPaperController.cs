using Microsoft.AspNetCore.Mvc;
using WebExamMVC.Models;
using WebExamMVC.Services;

namespace WebExamMVC.Controllers
{
    public class ExamPaperController(ExamService examService, QuestionService questionService, SubjectService subjectService, ExamPaperService examPaperService) : Controller
    {
        // Mock data for demonstration
        private static readonly List<ExamPaperModel> examPapers = new List<ExamPaperModel>
        {
            new ExamPaperModel
            {
                Id = 1,
                Exam = new ExamModel { Id = 1, ExamStart = DateTime.Now, ExamEnd = DateTime.Now.AddHours(2), Subject = new SubjectModel { Id = 1, Name = "Math" } },
                Questions = new List<QuestionModel>
                {
                    new QuestionModel
                    {
                        Id = 1,
                        Condition = "What is 2+2?",
                        Choises = new List<ChoiseModel>
                        {
                            new ChoiseModel { Id = 1, Answer = "3", IsTrue = false },
                            new ChoiseModel { Id = 2, Answer = "4", IsTrue = true },
                            new ChoiseModel { Id = 3, Answer = "5", IsTrue = false }
                        }
                    },
                    new QuestionModel
                    {
                        Id = 2,
                        Condition = "What is the capital of France?",
                        Choises = new List<ChoiseModel>
                        {
                            new ChoiseModel { Id = 4, Answer = "London", IsTrue = false },
                            new ChoiseModel { Id = 5, Answer = "Paris", IsTrue = true },
                            new ChoiseModel { Id = 6, Answer = "Berlin", IsTrue = false }
                        }
                    }
                }
            }
        };
        private static int paperId;
        public ActionResult Index()
        {
            //var model = examPapers.FirstOrDefault();
            //
            var exam = examService.Get().Result.First(e=> e.ExamStart.Day == DateTime.Now.Day);

            exam.Subject = subjectService.Get(exam.SubjectId).Result;

            var questions = questionService.Get().Result.Where(e=> e.SubjectId == exam.SubjectId).ToList();

            var model = new ExamPaperModel()
            {
                Exam = exam,
                Questions = questions,
            };
            paperId = examPaperService.Create(model).Result.Id;
            //
            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(List<int> selectedChoices)
        {
            int score = 0;

            if (selectedChoices.Count == 0)
            {
                ViewBag.Score = score;
                return View("Result");
            }

            var exam = examPaperService.Get(/*paperId*/10).Result;

            var questions = exam.Questions;

            
            for (int i = 0; i < questions.Count(); i++)
            {
                if (selectedChoices[i] == questions[i].Choises.First(c => c.IsTrue).Id)
                {
                    score++;
                }
            }

            ViewBag.Score = score;
            return View("Result");
        }
    }
}
