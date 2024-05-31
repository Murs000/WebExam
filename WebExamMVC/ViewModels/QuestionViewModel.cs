using WebExamMVC.Models;

namespace WebExamMVC.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public List<ChoiseModel> Choises { get; set; } = new List<ChoiseModel>();
        public int SubjectId { get; set; }
        public SubjectModel Subject { get; set; } = new SubjectModel();
        public List<SubjectModel> Subjects { get; set; } = new List<SubjectModel>();
        public int CorrectChoiceIndex { get; set; } = -1; // Track the index of the correct choice
    }
}
