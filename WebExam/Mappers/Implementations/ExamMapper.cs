using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;

namespace WebExam.Mappers.Implementations
{
    public class ExamMapper : IExamMapper
    {
        public ExamModel Map(Exam entity)
        {
            ExamModel model = new ExamModel()
            {
                Id = entity.Id,
                ExamStart = entity.ExamStart,
                ExamEnd = entity.ExamEnd,
                Subject = new Subject()
                {
                    Id=entity.Subject.Id,
                    Name = entity.Subject.Name,
                    Questions = new List<Question>(entity.Subject.Questions)
                },
            };
            return model;
        }

        public Exam Map(ExamModel model)
        {
            Exam entity = new Exam()
            {
                Id = model.Id,
                ExamStart = model.ExamStart,
                ExamEnd = model.ExamEnd,
                Subject = new Subject()
                {
                    Id = model.Subject.Id,
                    Name = model.Subject.Name,
                    Questions = new List<Question>(model.Subject.Questions)
                },
            };
            return entity;
        }

        public List<ExamModel> Map(List<Exam> entities)
        {
            List<ExamModel> models = [];
            foreach (var entity in entities)
            {
                ExamModel model = Map(entity);
                models.Add(model);
            }
            return models;
        }

        public List<Exam> Map(List<ExamModel> models)
        {
            List<Exam> entities = [];
            foreach (var model in models)
            {
                Exam entity = Map(model);
                entities.Add(entity);
            }
            return entities;
        }
    }
}
