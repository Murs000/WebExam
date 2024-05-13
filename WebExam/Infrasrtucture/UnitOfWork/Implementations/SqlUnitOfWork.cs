using WebExam.Infrasrtucture.UnitOfWork.Interfaces;

namespace WebExam.Infrasrtucture.UnitOfWork.Implementations
{
    public class SqlUnitOfWork(ExamAppDb context) : IUnitOfWork
    {
        //public ISubjectRepository SubjectRepository => new SqlSubjectRepository(context);
    }
}
