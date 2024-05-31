using WebExam.DataAccess.Repositorys.Implementations;
using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositories.Implementations.SqlServer
{
    public class SqlChoiseRepository : IChoiseRepository
    {
        private readonly ExamAppDb _context;
        public SqlChoiseRepository(ExamAppDb context)
        {
            _context = context;
        }
        public List<Choise> Get() => _context.Choises.ToList();
        public Choise Get(int entityId) => _context.Choises.First(e => e.Id == entityId);
        public int Insert(Choise entity)
        {
            _context.Choises.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
        public bool Update(Choise entity)
        {
            Choise entityFromDb = _context.Choises.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;


            entityFromDb.Id = entity.Id;
            entityFromDb.Answer = entity.Answer;
            entityFromDb.IsTrue = entity.IsTrue;

            _context.SaveChanges();

            return true;
        }
        public bool Delete(int entityId)
        {
            Choise entityFromDb = _context.Choises.First(e => e.Id == entityId);
            if (entityFromDb == null) return false;

            _context.Choises.Remove(entityFromDb);
            _context.SaveChanges();

            return true;
        }


        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
