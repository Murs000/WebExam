using WebExam.Entity.Implementations;
using Microsoft.EntityFrameworkCore;
using WebExam.Models.Implementations;

namespace WebExam.DataAccess.Repositorys.Implementations
{
    public class ExamAppDb : DbContext
    {
        public ExamAppDb(DbContextOptions<ExamAppDb> options) : base(options) { }
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Choise> Choises => Set<Choise>();

        public DbSet<ExamQuestions> ExamQuestions => Set<ExamQuestions>();

        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<ExamPaper> ExamPapers => Set<ExamPaper>();

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamQuestions>()
                .HasOne(eq => eq.Question)
                .WithMany()
                .HasForeignKey(eq => eq.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ExamQuestions>()
                .HasOne(eq => eq.ExamPaper)
                .WithMany()
                .HasForeignKey(eq => eq.ExamPaperId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
