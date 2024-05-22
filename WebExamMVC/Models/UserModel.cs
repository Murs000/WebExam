using WebExamMVC.Enums;
namespace WebExamMVC.Models
{
    public class UserModel 
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
