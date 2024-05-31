using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class SubjectService(IUnitOfWork repository) : ISubjectService
    {
        public List<Subject> Get() => repository.SubjectRepository.Get();
        public Subject Get(int modelId) => repository.SubjectRepository.Get(modelId);
        public int Insert(Subject model) => repository.SubjectRepository.Insert(model);
        public bool Update(Subject model) => repository.SubjectRepository.Update(model);

        public bool Delete(int modelId) => repository.SubjectRepository.Delete(modelId);
    }
}
