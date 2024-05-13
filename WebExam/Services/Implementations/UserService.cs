using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class UserService(IMapperUnitOfWork mapper, IUnitOfWork repository) : IUserService
    {
        public List<UserModel> Get() => mapper.UserMapper.Map(repository.UserRepository.Get());
        public UserModel Get(int modelId) => mapper.UserMapper.Map(repository.UserRepository.Get(modelId));
        public UserModel GetByLogin(string login) => mapper.UserMapper.Map(repository.UserRepository.GetByLogin(login));
        public int Insert(UserModel model) => repository.UserRepository.Insert(mapper.UserMapper.Map(model));
        public bool Update(UserModel model) => repository.UserRepository.Update(mapper.UserMapper.Map(model));
        public bool Delete(int modelId) => repository.UserRepository.Delete(modelId);
    }
}
