using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class ChoiseService(IMapperUnitOfWork mapper, IUnitOfWork repository) : IChoiseService
    {
        public List<ChoiseModel> Get() => mapper.ChoiseMapper.Map(repository.ChoiseRepository.Get());
        public ChoiseModel Get(int modelId) => mapper.ChoiseMapper.Map(repository.ChoiseRepository.Get(modelId));
        public int Insert(ChoiseModel model) => repository.ChoiseRepository.Insert(mapper.ChoiseMapper.Map(model));
        public bool Update(ChoiseModel model) => repository.ChoiseRepository.Update(mapper.ChoiseMapper.Map(model));

        public bool Delete(int modelId) => repository.ChoiseRepository.Delete(modelId);
    }
}
