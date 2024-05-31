using WebExam.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebExam.Entity.Implementations
{
    public class Question : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = new Subject();
    }
}
