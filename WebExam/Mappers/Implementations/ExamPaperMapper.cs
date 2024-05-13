using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;

namespace WebExam.Mappers.Implementations
{
    public class ExamPaperMapper : IExamPaperMapper
    {
        public ExamPaperModel Map(ExamPaper entity)
        {
            ExamPaperModel model = new ExamPaperModel()
            {
                Id = entity.Id,
                Exam = new Exam()
                {
                    Id = entity.Exam.Id,
                    ExamStart = entity.Exam.ExamStart,
                    ExamEnd = entity.Exam.ExamEnd,
                    Subject = new Subject()
                    {
                        Id = entity.Exam.Subject.Id,
                        Name = entity.Exam.Subject.Name,
                        Questions = new List<Question>(entity.Exam.Subject.Questions)
                    },
                },
                Questions = new List<Question>(entity.Questions)
            };
            return model;
        }

        public ExamPaper Map(ExamPaperModel model)
        {
            ExamPaper entity = new ExamPaper()
            {
                Id = model.Id,
                Exam = new Exam()
                {
                    Id = model.Exam.Id,
                    ExamStart = model.Exam.ExamStart,
                    ExamEnd = model.Exam.ExamEnd,
                    Subject = new Subject()
                    {
                        Id = model.Exam.Subject.Id,
                        Name = model.Exam.Subject.Name,
                        Questions = new List<Question>(model.Exam.Subject.Questions)
                    },
                },
                Questions = new List<Question>(model.Questions)
            };
            return entity;
        }

        public List<ExamPaperModel> Map(List<ExamPaper> entities)
        {
            List<ExamPaperModel> models = [];
            foreach (var entity in entities)
            {
                ExamPaperModel model = Map(entity);
                models.Add(model);
            }
            return models;
        }

        public List<ExamPaper> Map(List<ExamPaperModel> models)
        {
            List<ExamPaper> entities = [];
            foreach (var model in models)
            {
                ExamPaper entity = Map(model);
                entities.Add(entity);
            }
            return entities;
        }
    }
}
