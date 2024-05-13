namespace WebExam.Services.Interfaces
{
    public interface IServiceUnitOfWork
    {
        public ISubjectService SubjectService { get; }
        public IQuestionService QuestionService { get; }
        public IChoiseService ChoiseService { get; }

        public IExamService ExamService { get; }
        public IExamPaperService ExamPaperService { get; }
    }
}
