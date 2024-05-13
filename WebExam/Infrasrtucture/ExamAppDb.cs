using Microsoft.EntityFrameworkCore;

namespace WebExam.Infrasrtucture
{
    public class ExamAppDb : DbContext
    {
        public ExamAppDb(DbContextOptions<ExamAppDb> options) : base(options) { }
        //public DbSet<SubjectEntity> Subjects => Set<SubjectEntity>();
    }
}
