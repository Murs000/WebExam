using WebExam.DataAccess.Repositorys.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;

namespace WebExam.Mappers.Implementations
{
    public class ChoiseMapper : IChoiseMapper
    {
        public ChoiseModel Map(Choise entity)
        {
            ChoiseModel model = new ChoiseModel()
            {
                Id = entity.Id,
                Answer = entity.Answer,
                IsTrue = entity.IsTrue,
                Question = new Question()
                {
                    Id = entity.Id,
                    Condition = entity.Question.Condition,
                    Choises = new List<Choise>(entity.Question.Choises),
                    Subject = new Subject()
                    {
                        Id = entity.Question.Subject.Id,
                        Name = entity.Question.Subject.Name,
                        Questions = new List<Question>(entity.Question.Subject.Questions)
                    },
                }
            };
            return model;
        }

        public Choise Map(ChoiseModel model)
        {
            Choise entity = new Choise()
            {
                Id = model.Id,
                Answer = model.Answer,
                IsTrue = model.IsTrue,
                Question = new Question()
                {
                    Id = model.Id,
                    Condition = model.Question.Condition,
                    Choises = new List<Choise>(model.Question.Choises),
                    Subject = new Subject()
                    {
                        Id = model.Question.Subject.Id,
                        Name = model.Question.Subject.Name,
                        Questions = new List<Question>(model.Question.Subject.Questions)
                    },
                }
            };
            return entity;
        }

        public List<ChoiseModel> Map(List<Choise> entities)
        {
            List<ChoiseModel> models = new List<ChoiseModel>();
            foreach (var entity in entities)
            {
                ChoiseModel model = Map(entity);
                models.Add(model);
            }
            return models;
        }

        public List<Choise> Map(List<ChoiseModel> models)
        {
            List<Choise> entities = new List<Choise>();
            foreach (var model in models)
            {
                Choise entity = Map(model);
                entities.Add(entity);
            }
            return entities;
        }
    }
}
