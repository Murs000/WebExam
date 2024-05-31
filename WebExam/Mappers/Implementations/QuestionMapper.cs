using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;

namespace WebExam.Mappers.Implementations
{
    public class QuestionMapper : IQuestionMapper
    {
        public QuestionModel Map(Question entity)
        {
            QuestionModel model = new QuestionModel()
            {
                Id = entity.Id,
                Condition = entity.Condition,
                SubjectId = entity.SubjectId,
                Subject = new Subject()
                {
                    Id=entity.Subject.Id,
                    Name = entity.Subject.Name,
                },
            };
            return model;
        }

        public Question Map(QuestionModel model)
        {
            Question entity = new Question()
            {
                Id = model.Id,
                Condition = model.Condition,
                SubjectId = model.SubjectId,
                Subject = new Subject()
                {
                    Id = model.Subject.Id,
                    Name = model.Subject.Name,
                },
            };
            return entity;
        }

        public List<QuestionModel> Map(List<Question> entities)
        {
            List<QuestionModel> models = new List<QuestionModel>();
            foreach (var entity in entities)
            {
                QuestionModel model = Map(entity);
                models.Add(model);
            }
            return models;
        }

        public List<Question> Map(List<QuestionModel> models)
        {
            List<Question> entities = new List<Question>();
            foreach (var model in models)
            {
                Question entity = Map(model);
                entities.Add(entity);
            }
            return entities;
        }
    }
}
