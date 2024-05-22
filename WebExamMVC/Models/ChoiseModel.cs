
namespace WebExamMVC.Models
{
    public class ChoiseModel 
    {
        public int Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public int QuestionId => Question.Id;
        public QuestionModel Question { get; set; } = new QuestionModel();
        public bool IsTrue { get; set; } = false;
    }
}
