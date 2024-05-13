using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Implementations;
using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositories.Implementations.SqlServer
{
    public class SqlExamRepository(ExamAppDb context) : IExamRepository
    {
        public List<Exam> Get() => context.Exams.ToList();
        public Exam Get(int entityId) => context.Exams.First(e => e.Id == entityId);
        public int Insert(Exam entity)
        {
            context.Exams.Add(entity);
            context.SaveChanges();

            return entity.Id;
        }
        public bool Update(Exam entity)
        {
            Exam entityFromDb = context.Exams.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;

            entityFromDb = new Exam
            {
                Id = entity.Id,
                ExamStart = entity.ExamStart,
                ExamEnd = entity.ExamEnd,
                Subject = context.Subjects.First(e => e.Id == entity.SubjectId),
            };

            context.Update(entityFromDb);
            context.SaveChanges();

            return true;
        }
        public bool Delete(int entityId)
        {
            Exam entityFromDb = context.Exams.First(e => e.Id == entityId);
            if (entityFromDb == null) return false;

            context.Exams.Remove(entityFromDb);
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
