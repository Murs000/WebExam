using WebExam.DataAccess.Repositorys.Interfaces;

namespace WebExam.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public ISubjectRepository SubjectRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        public IChoiseRepository ChoiseRepository { get; }

        public IExamRepository ExamRepository { get; }
        public IExamPaperRepository ExamPaperRepository { get; }
    }
}
