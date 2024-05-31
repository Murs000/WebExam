using Microsoft.EntityFrameworkCore;
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
            int existingSubjectId = entity.Subject.Id;

            // Check if the Subject entity with the existingSubjectId is already tracked by the context
            var existingSubject = context.Subjects.First(e => e.Id == existingSubjectId);

            if (existingSubject != null)
            {
                // If the existingSubjectId is already tracked, use it directly
                var newExam = new Exam
                {
                    ExamStart = entity.ExamStart,
                    ExamEnd = entity.ExamEnd,
                    SubjectId = existingSubjectId,  // Set the SubjectId property to reference the existing Subject
                    Subject = existingSubject,
                };

                // Add the new Question entity to the context
                context.Exams.Add(newExam);

                // Save changes to the database
                context.SaveChanges();

                entity.Id = newExam.Id;
            }
            return entity.Id;
        }
        public bool Update(Exam entity)
        {
            Exam entityFromDb = context.Exams.First(e => e.Id == entity.Id);
            if (entityFromDb == null) return false;


            entityFromDb.Id = entity.Id;
            entityFromDb.ExamStart = entity.ExamStart;
            entityFromDb.ExamEnd = entity.ExamEnd;
            entityFromDb.Subject = context.Subjects.First(e => e.Id == entity.SubjectId);

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
