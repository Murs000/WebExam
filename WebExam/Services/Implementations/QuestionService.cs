using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class QuestionService(IMapperUnitOfWork mapper, IUnitOfWork repository) : IQuestionService
    {
        public List<QuestionModel> Get() => mapper.QuestionMapper.Map(repository.QuestionRepository.Get());
        public QuestionModel Get(int modelId) => mapper.QuestionMapper.Map(repository.QuestionRepository.Get(modelId));
        public int Insert(QuestionModel model) => repository.QuestionRepository.Insert(mapper.QuestionMapper.Map(model));
        public bool Update(QuestionModel model) => repository.QuestionRepository.Update(mapper.QuestionMapper.Map(model));

        public bool Delete(int modelId) => repository.QuestionRepository.Delete(modelId);
    }
}
