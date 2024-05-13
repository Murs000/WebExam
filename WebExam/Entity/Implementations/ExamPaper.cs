using WebExam.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebExam.Entity.Implementations
{
    public class ExamPaper : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ExamId => Exam.Id;
        public Exam Exam { get; set; } = new Exam();
        public List<Question> Questions { get; set; } = [];
    }
}
