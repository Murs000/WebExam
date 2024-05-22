
namespace WebExamMVC.Models
{
    public class ExamPaperModel 
    {
        public int Id { get; set; }
        public int ExamId => Exam.Id;
        public ExamModel Exam { get; set; } = new ExamModel();
        public List<QuestionModel> Questions { get; set; } = [];
    }
}
