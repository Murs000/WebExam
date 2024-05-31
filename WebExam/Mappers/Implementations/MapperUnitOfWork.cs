using WebExam.Mappers.Interfaces;

namespace WebExam.Mappers.Implementations
{
    public class MapperUnitOfWork : IMapperUnitOfWork
    {
        public IQuestionMapper QuestionMapper => new QuestionMapper();
        public IExamPaperMapper ExamPaperMapper => new ExamPaperMapper();

    }
}
