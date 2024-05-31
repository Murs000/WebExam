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
            int existingSubjectId = entity.Subject.Id;

            // Check if the Subject entity with the existingSubjectId is already tracked by the context
            var existingSubject = _context.Subjects.First(e => e.Id == existingSubjectId);

            if (existingSubject != null)
            {
                // If the existingSubjectId is already tracked, use it directly
                var newQuestion = new Question
                {
                    Condition = entity.Condition,
                    SubjectId = existingSubjectId,  // Set the SubjectId property to reference the existing Subject
                    Subject = existingSubject,
                };

                // Add the new Question entity to the context
                _context.Questions.Add(newQuestion);

                // Save changes to the database
                _context.SaveChanges();

                entity.Id = newQuestion.Id;
            }
            return entity.Id;
        }
        public bool Update(Question entity)
        {
            Question entityFromDb = _context.Questions.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;


            entityFromDb.Id = entity.Id;
            entityFromDb.Condition = entity.Condition;
            entityFromDb.Subject = _context.Subjects.First(e => e.Id == entity.Subject.Id);
            
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
