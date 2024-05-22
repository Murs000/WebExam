using Microsoft.EntityFrameworkCore;
using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Implementations;
using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositories.Implementations.SqlServer
{
    public class SqlUserRepository(ExamAppDb context) : IUserRepository
    {
        public List<User> Get() => context.Users.ToList();
        public User Get(int entityId) => context.Users.First(e => e.Id == entityId);
        public User GetByLogin(string login) => context.Users.First(e => e.Login == login);
        public int Insert(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();

            return entity.Id;
        }
        public bool Update(User entity)
        {
            User entityFromDb = context.Users.First(e => e.Id == entity.Id);
            if (entityFromDb == null) 
                return false;

            entityFromDb.Login = entity.Login;
            entityFromDb.Name = entity.Name;
            entityFromDb.Role = entity.Role;
            entityFromDb.Surname = entity.Surname;
            entityFromDb.PasswordHash = entity.PasswordHash;

            context.SaveChanges();

            return true;
        }
        public bool Delete(int entityId)
        {
            User entityFromDb = context.Users.First(e => e.Id == entityId);
            if (entityFromDb == null) return false;

            context.Users.Remove(entityFromDb);
            context.SaveChanges();

            return true;
        }


        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
