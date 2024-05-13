using WebExam.DataAccess.Repositorys.Implementations;
using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositories.Implementations.SqlServer
{
    public class SqlQuestionRepository : IQuestionRepository
    {
        private readonly ExamAppDb _context;
        public SqlQuestionRepository(ExamAppDb context)
        {
            _context = context;
        }
        public List<Question> Get() => _context.Questions.ToList();
        public Question Get(int entityId) => _context.Questions.First(e => e.Id == entityId);
        public int Insert(Question entity)
        {
            _context.Questions.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }
        public bool Update(Question entity)
        {
            Question entityFromDb = _context.Questions.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;

            entityFromDb = new Question
            {
                Id = entity.Id,
                Condition = entity.Condition,
                Choises = new List<Choise>(entityFromDb.Choises)
            };

            _context.Update(entityFromDb);
            _context.SaveChanges();

            return true;
        }
        public bool Delete(int entityId)
        {
            Question entityFromDb = _context.Questions.First(e => e.Id == entityId);
            if (entityFromDb == null) return false;

            _context.Questions.Remove(entityFromDb);
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
