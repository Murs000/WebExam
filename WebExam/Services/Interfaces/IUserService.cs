using WebExam.Models.Implementations;

namespace WebExam.Services.Interfaces
{
    public interface IUserService : IService<UserModel>
    {
        public UserModel GetByLogin(string login);
    }
}
