using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Implementations;
using WebExam.DataAccess.Repositorys.Implementations.SqlServer;
using WebExam.DataAccess.Repositorys.Interfaces;

namespace WebExam.DataAccess.Repositories.Implementations.SqlServer
{
    public class SqlUnitOfWork(ExamAppDb context) : IUnitOfWork
    {
        public ISubjectRepository SubjectRepository => new SqlSubjectRepository(context);

        public IQuestionRepository QuestionRepository => new SqlQuestionRepository(context);

        public IChoiseRepository ChoiseRepository => new SqlChoiseRepository(context);

        public IExamRepository ExamRepository => new SqlExamRepository(context);
        public IExamPaperRepository ExamPaperRepository => new SqlExamPaperRepository(context);
    }
}
