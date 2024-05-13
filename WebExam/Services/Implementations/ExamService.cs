using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class ExamService(IMapperUnitOfWork mapper, IUnitOfWork repository) : IExamService
    {
        public List<ExamModel> Get() => mapper.ExamMapper.Map(repository.ExamRepository.Get());
        public ExamModel Get(int modelId) => mapper.ExamMapper.Map(repository.ExamRepository.Get(modelId));
        public int Insert(ExamModel model) => repository.ExamRepository.Insert(mapper.ExamMapper.Map(model));
        public bool Update(ExamModel model) => repository.ExamRepository.Update(mapper.ExamMapper.Map(model));
        public bool Delete(int modelId) => repository.ExamRepository.Delete(modelId);
    }
}
