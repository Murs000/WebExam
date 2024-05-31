using System.ComponentModel.DataAnnotations;
using WebExam.Entity.Interfaces;

namespace WebExam.Entity.Implementations
{
    public class ExamQuestions :IEntity
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } = new Question();
        public int ExamPaperId { get; set; }
        public ExamPaper ExamPaper { get; set; } = new ExamPaper();
    }
}
