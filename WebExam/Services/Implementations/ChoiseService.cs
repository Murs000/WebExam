using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class ChoiseService(IUnitOfWork repository) : IChoiseService
    {
        public List<Choise> Get() => repository.ChoiseRepository.Get();
        public Choise Get(int modelId) => repository.ChoiseRepository.Get(modelId);
        public int Insert(Choise model) => repository.ChoiseRepository.Insert(model);
        public bool Update(Choise model) => repository.ChoiseRepository.Update(model);

        public bool Delete(int modelId) => repository.ChoiseRepository.Delete(modelId);
    }
}
