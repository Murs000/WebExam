using WebExam.Entity.Implementations;
using WebExam.Models.Interfaces;

namespace WebExam.Models.Implementations
{
    public class ChoiseModel : IApiModel
    {
        public int Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public int QuestionId => Question.Id;
        public Question Question { get; set; } = new Question();
        public bool IsTrue { get; set; } = false;
    }
}
