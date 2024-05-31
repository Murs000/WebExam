using WebExam.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebExam.Entity.Implementations
{
    public class Exam : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime ExamStart { get; set; }
        public DateTime ExamEnd { get; set;}
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
