using WebExam.Infrasrtucture.UnitOfWork.Interfaces;

namespace WebExam.Infrasrtucture.UnitOfWork.Implementations
{
    public class ServiceUnitOfWork(IMapperUnitOfWork mapper, IUnitOfWork repository) : IServiceUnitOfWork
    {
        //public ISubjectService SubjectService => new SubjectService(mapper, repository);
    }
}
