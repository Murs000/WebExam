using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositorys.Implementations.SqlServer
{
    public class SqlSubjectRepository : ISubjectRepository
    {
        private readonly ExamAppDb _context;
        public SqlSubjectRepository(ExamAppDb context)
        {
            _context = context;
        }
        public List<Subject> Get() => _context.Subjects.ToList();
        public Subject Get(int entityId) => _context.Subjects.First(e => e.Id == entityId);
        public int Insert(Subject entity)
        {
            _context.Subjects.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
        public bool Update(Subject entity)
        {
            Subject entityFromDb = _context.Subjects.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;

            entityFromDb.Id = entity.Id;
            entityFromDb.Name = entity.Name;

            _context.SaveChanges();

            return true;
        }
        public bool Delete(int entityId)
        {
            Subject entityFromDb = _context.Subjects.First(e => e.Id == entityId);
            if (entityFromDb == null) return false;

            _context.Subjects.Remove(entityFromDb);
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
