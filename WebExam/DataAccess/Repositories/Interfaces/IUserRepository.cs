using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetByLogin(string login);
    }
}
