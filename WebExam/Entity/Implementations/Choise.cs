using WebExam.Entity.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace WebExam.Entity.Implementations
{
    public class Choise : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public int QuestionId => Question.Id;
        public Question Question { get; set; } = new Question();
        public bool IsTrue { get; set; } = false;
    }
}
