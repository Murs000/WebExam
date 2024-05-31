using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class UserService(IUnitOfWork repository) : IUserService
    {
        public List<User> Get() => repository.UserRepository.Get();
        public User Get(int modelId) => repository.UserRepository.Get(modelId);
        public User GetByLogin(string login) => repository.UserRepository.GetByLogin(login);
        public int Insert(User model) => repository.UserRepository.Insert(model);
        public bool Update(User model) => repository.UserRepository.Update(model);
        public bool Delete(int modelId) => repository.UserRepository.Delete(modelId);
    }
}
