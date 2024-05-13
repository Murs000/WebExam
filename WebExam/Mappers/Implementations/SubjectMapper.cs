using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;

namespace WebExam.Mappers.Implementations
{
    public class SubjectMapper : ISubjectMapper
    {
        public SubjectModel Map(Subject entity)
        {
            SubjectModel model = new SubjectModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Questions = new List<Question>(entity.Questions),
            };
            return model;
        }

        public Subject Map(SubjectModel model)
        {
            Subject entity = new Subject()
            {
                Id = model.Id,
                Name = model.Name,
                Questions = new List<Question>(model.Questions)
            };
            return entity;
        }

        public List<SubjectModel> Map(List<Subject> entities)
        {
            List<SubjectModel> models = new List<SubjectModel>();
            foreach (var entity in entities)
            {
                SubjectModel model = Map(entity);
                models.Add(model);
            }
            return models;
        }

        public List<Subject> Map(List<SubjectModel> models)
        {
            List<Subject> entities = new List<Subject>();
            foreach (var model in models)
            {
                Subject entity = Map(model);
                entities.Add(entity);
            }
            return entities;
        }
    }
}
