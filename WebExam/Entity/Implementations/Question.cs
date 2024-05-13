using WebExam.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebExam.Entity.Implementations
{
    public class Question : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public List<Choise> Choises { get; set; } = [];
        public int SubjectId => Subject.Id;
        public Subject Subject { get; set; } = new Subject();
    }
}
