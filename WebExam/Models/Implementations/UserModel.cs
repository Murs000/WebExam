using WebExam.Enum;
using WebExam.Models.Interfaces;

namespace WebExam.Models.Implementations
{
    public class UserModel : IApiModel
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
