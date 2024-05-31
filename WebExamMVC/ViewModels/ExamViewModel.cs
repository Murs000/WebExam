using WebExamMVC.Models;

namespace WebExamMVC.ViewModels
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public DateTime ExamStart { get; set; } = DateTime.Now.AddMinutes(-DateTime.Now.Minute).AddMilliseconds(-DateTime.Now.Millisecond).AddMicroseconds(-DateTime.Now.Microsecond); 
        public int ExamDuration { get; set; }
        public int SubjectId {get; set;}
        public SubjectModel Subject { get; set; } = new SubjectModel();
        public List<SubjectModel> Subjects { get; set; } = [];
    }
}
