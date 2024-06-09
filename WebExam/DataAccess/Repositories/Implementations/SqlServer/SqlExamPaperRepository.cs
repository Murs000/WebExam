using Microsoft.EntityFrameworkCore;
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
            // Fetch existing subject
            int existingSubjectId = entity.Exam.SubjectId;
            var existingSubject = context.Subjects.First(e => e.Id == existingSubjectId);

            // Fetch existing exam
            int existingExamId = entity.ExamId;
            var existingExam = context.Exams.First(e => e.Id == existingExamId);

            // Create new ExamPaper entity
            ExamPaper newEntity = new ExamPaper()
            {
                ExamId = existingExam.Id,
                Exam = existingExam
            };

            // Add the new ExamPaper to the context
            context.ExamPapers.Add(newEntity);

            // Save changes to the database
            context.SaveChanges();

            return newEntity.Id;
        }

        
        public bool Update(ExamPaper entity)
        {
            ExamPaper entityFromDb = context.ExamPapers.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;

            entityFromDb.Id = entity.Id;
            entityFromDb.Exam = context.Exams.First(e => e.Id == entity.ExamId);

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
