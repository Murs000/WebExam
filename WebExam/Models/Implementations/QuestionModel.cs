using WebExam.Entity.Implementations;
using WebExam.Models.Interfaces;

namespace WebExam.Models.Implementations
{
    public class QuestionModel : IApiModel
    {
        public int Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public List<Choise> Choises { get; set; } = [];
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = new Subject();
    }
}
