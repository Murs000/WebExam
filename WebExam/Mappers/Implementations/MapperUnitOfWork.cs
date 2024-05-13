using WebExam.Mappers.Interfaces;

namespace WebExam.Mappers.Implementations
{
    public class MapperUnitOfWork : IMapperUnitOfWork
    {
        public ISubjectMapper SubjectMapper => new SubjectMapper();
        public IQuestionMapper QuestionMapper => new QuestionMapper();
        public IChoiseMapper ChoiseMapper => new ChoiseMapper();

        public IExamMapper ExamMapper => new ExamMapper();
        public IExamPaperMapper ExamPaperMapper => new ExamPaperMapper();

        public IUserMapper UserMapper => new UserMapper();
    }
}
