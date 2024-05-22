
namespace WebExamMVC.Models
{
    public class ExamModel 
    {
        public int Id { get; set; }
        public DateTime ExamStart { get; set; }
        public DateTime ExamEnd { get; set; }
        public int SubjectId => Subject.Id;
        public SubjectModel Subject { get; set; } = new SubjectModel();
    }
}
