using System.ComponentModel.DataAnnotations;
using WebExam.Entity.Interfaces;
using WebExam.Enum;

namespace WebExam.Entity.Implementations
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
