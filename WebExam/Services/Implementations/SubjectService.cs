using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class SubjectService(IMapperUnitOfWork mapper, IUnitOfWork repository) : ISubjectService
    {
        public List<SubjectModel> Get() => mapper.SubjectMapper.Map(repository.SubjectRepository.Get());
        public SubjectModel Get(int modelId) => mapper.SubjectMapper.Map(repository.SubjectRepository.Get(modelId));
        public int Insert(SubjectModel model) => repository.SubjectRepository.Insert(mapper.SubjectMapper.Map(model));
        public bool Update(SubjectModel model) => repository.SubjectRepository.Update(mapper.SubjectMapper.Map(model));

        public bool Delete(int modelId) => repository.SubjectRepository.Delete(modelId);
    }
}
