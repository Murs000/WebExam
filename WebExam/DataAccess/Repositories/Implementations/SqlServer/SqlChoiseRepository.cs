using WebExam.DataAccess.Repositorys.Implementations;
using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositories.Implementations.SqlServer
{
    public class SqlChoiseRepository(ExamAppDb context) : IChoiseRepository
    {
        public List<Choise> Get() => context.Choises.ToList();
        public Choise Get(int entityId) => context.Choises.First(e => e.Id == entityId);
        public List<Choise> GetByQuestion(int QuestionId) => context.Choises.Where(e =>  e.QuestionId == QuestionId).ToList();
        public int Insert(Choise entity)
        {
            context.Choises.Add(entity);
            context.SaveChanges();

            return entity.Id;
        }
        public bool Update(Choise entity)
        {
            Choise entityFromDb = context.Choises.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;


            entityFromDb.Id = entity.Id;
            entityFromDb.Answer = entity.Answer;
            entityFromDb.IsTrue = entity.IsTrue;

            context.SaveChanges();

            return true;
        }
        public bool Delete(int entityId)
        {
            Choise entityFromDb = context.Choises.First(e => e.Id == entityId);
            if (entityFromDb == null) return false;

            context.Choises.Remove(entityFromDb);
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
