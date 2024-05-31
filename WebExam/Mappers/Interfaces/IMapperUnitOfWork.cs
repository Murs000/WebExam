namespace WebExam.Mappers.Interfaces
{
    public interface IMapperUnitOfWork
    {
        public IQuestionMapper QuestionMapper { get; }
        public IExamPaperMapper ExamPaperMapper { get; }

    }
}
