using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Implementations;
using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositories.Implementations.SqlServer
{
    public class SqlExamPaperRepository(ExamAppDb context) : IExamPaperRepository
    {
        public List<ExamPaper> Get() => context.ExamPapers.ToList();
        public ExamPaper Get(int entityId) => context.ExamPapers.First(e => e.Id == entityId);
        public int Insert(ExamPaper entity)
        {
            context.ExamPapers.Add(entity);
            context.SaveChanges();

            return entity.Id;
        }
        public bool Update(ExamPaper entity)
        {
            ExamPaper entityFromDb = context.ExamPapers.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;

            entityFromDb = new ExamPaper
            {
                Id = entity.Id,
                Exam = context.Exams.First(e => e.Id == entity.ExamId),
                Questions = new List<Question>(entity.Questions)
            };

            context.Update(entityFromDb);
            context.SaveChanges();

            return true;
        }
        public bool Delete(int entityId)
        {
            ExamPaper entityFromDb = context.ExamPapers.First(e => e.Id == entityId);
            if (entityFromDb == null) return false;

            context.ExamPapers.Remove(entityFromDb);
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
