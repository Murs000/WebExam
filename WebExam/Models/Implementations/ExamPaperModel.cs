using WebExam.Entity.Implementations;
using WebExam.Models.Interfaces;

namespace WebExam.Models.Implementations
{
    public class ExamPaperModel : IApiModel
    {
        public int Id { get; set; }
        public int ExamId => Exam.Id;
        public Exam Exam { get; set; } = new Exam();
        public List<Question> Questions { get; set; } = [];
    }
}
