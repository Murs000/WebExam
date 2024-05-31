using WebExam.Entity.Implementations;
using WebExam.Models.Implementations;

namespace WebExam.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        public User GetByLogin(string login);
    }
}
