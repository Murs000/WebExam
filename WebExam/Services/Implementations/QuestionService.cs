using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class QuestionService(IMapperUnitOfWork mapper, IUnitOfWork repository) : IQuestionService
    {
        public List<QuestionModel> Get()
        {
            List<QuestionModel> models = mapper.QuestionMapper.Map(repository.QuestionRepository.Get());

            foreach (QuestionModel model in models)
            {
                model.Choises = new List<Choise>(repository.ChoiseRepository.Get().Where(e => e.QuestionId == model.Id));
                model.Subject = repository.SubjectRepository.Get().First(e => e.Id == model.SubjectId);
            }

            return models;
        }
        public QuestionModel Get(int modelId)
        {
            QuestionModel model = mapper.QuestionMapper.Map(repository.QuestionRepository.Get(modelId));

            model.Choises = new List<Choise>(repository.ChoiseRepository.Get().Where(e => e.QuestionId == model.Id));

            return model;
        }
        public int Insert(QuestionModel model)
        {
            int questionId = repository.QuestionRepository.Insert(mapper.QuestionMapper.Map(model));

            foreach(var choise in model.Choises)
            {
                choise.QuestionId = questionId;
                choise.Question = repository.QuestionRepository.Get(questionId);
                repository.ChoiseRepository.Insert(choise);
            }

            return questionId;
        }
        public bool Update(QuestionModel model)
        {
            if (repository.QuestionRepository.Update(mapper.QuestionMapper.Map(model)))
            {
                foreach (var choise in model.Choises)
                {
                    if (!repository.ChoiseRepository.Update(choise))
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool Delete(int modelId) => repository.QuestionRepository.Delete(modelId);
    }
}
