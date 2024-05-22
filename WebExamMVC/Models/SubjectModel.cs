namespace WebExamMVC.Models
{
    public class SubjectModel 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<QuestionModel> Questions { get; set; } = [];
    }
}
