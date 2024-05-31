using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Mappers.Interfaces;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class ServiceUnitOfWork(IMapperUnitOfWork mapper, IUnitOfWork repository) : IServiceUnitOfWork
    {
        public ISubjectService SubjectService => new SubjectService(repository);
        public IQuestionService QuestionService => new QuestionService(mapper, repository);
        public IChoiseService ChoiseService => new ChoiseService(repository);

        public IExamService ExamService => new ExamService(repository);
        public IExamPaperService ExamPaperService => new ExamPaperService(mapper, repository);

        public IUserService UserService => new UserService(repository);
    }
}
