using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Mappers.Interfaces;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class ServiceUnitOfWork(IMapperUnitOfWork mapper, IUnitOfWork repository) : IServiceUnitOfWork
    {
        public ISubjectService SubjectService => new SubjectService(mapper, repository);
        public IQuestionService QuestionService => new QuestionService(mapper, repository);
        public IChoiseService ChoiseService => new ChoiseService(mapper, repository);

        public IExamService ExamService => new ExamService(mapper, repository);
        public IExamPaperService ExamPaperService => new ExamPaperService(mapper, repository);

        public IUserService UserService => new UserService(mapper, repository);
    }
}
