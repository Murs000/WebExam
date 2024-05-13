using WebExam.Entity.Implementations;
using WebExam.Models.Interfaces;

namespace WebExam.Models.Implementations
{
    public class ExamModel : IApiModel
    {
        public int Id { get; set; }
        public DateTime ExamStart { get; set; }
        public DateTime ExamEnd { get; set; }
        public int SubjectId => Subject.Id;
        public Subject Subject { get; set; } = new Subject();
    }
}
