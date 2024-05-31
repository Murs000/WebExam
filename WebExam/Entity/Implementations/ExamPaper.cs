using WebExam.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebExam.Entity.Implementations
{
    public class ExamPaper : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; } = new Exam();
    }
}
