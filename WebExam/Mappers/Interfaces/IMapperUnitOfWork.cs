namespace WebExam.Mappers.Interfaces
{
    public interface IMapperUnitOfWork
    {
        public ISubjectMapper SubjectMapper { get; }
        public IQuestionMapper QuestionMapper { get; }
        public IChoiseMapper ChoiseMapper { get; }

        public IExamMapper ExamMapper { get; }
        public IExamPaperMapper ExamPaperMapper { get; }

        public IUserMapper UserMapper { get; }
    }
}
