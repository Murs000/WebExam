using WebExam.Entity.Implementations;
using WebExam.Models.Interfaces;

namespace WebExam.Models.Implementations
{
    public class SubjectModel : IApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = [];
    }
}
