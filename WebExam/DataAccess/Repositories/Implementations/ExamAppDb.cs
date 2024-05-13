using WebExam.Entity.Implementations;
using Microsoft.EntityFrameworkCore;

namespace WebExam.DataAccess.Repositorys.Implementations
{
    public class ExamAppDb : DbContext
    {
        public ExamAppDb(DbContextOptions<ExamAppDb> options) : base(options) { }
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Choise> Choises => Set<Choise>();

        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<ExamPaper> ExamPapers => Set<ExamPaper>();

        public DbSet<User> Users => Set<User>();
    }
}
