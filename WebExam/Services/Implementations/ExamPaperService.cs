using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class ExamPaperService(IMapperUnitOfWork mapper, IUnitOfWork repository) : IExamPaperService
    {
        public List<ExamPaperModel> Get() => mapper.ExamPaperMapper.Map(repository.ExamPaperRepository.Get());
        public ExamPaperModel Get(int modelId) => mapper.ExamPaperMapper.Map(repository.ExamPaperRepository.Get(modelId));
        public int Insert(ExamPaperModel model)
        {
            ExamPaper examPaper = mapper.ExamPaperMapper.Map(model);

            var questions= repository.QuestionRepository.Get().Where(e => e.SubjectId == examPaper.Exam.SubjectId).ToList();
            var uniqueQuestions = UniqueQuestions(questions,20);

            return repository.ExamPaperRepository.Insert(examPaper);
        } 
        public bool Update(ExamPaperModel model) => repository.ExamPaperRepository.Update(mapper.ExamPaperMapper.Map(model));
        public bool Delete(int modelId) => repository.ExamPaperRepository.Delete(modelId);

        private List<Question> UniqueQuestions(List<Question> questions,int numberOfQuestions)
        {
            List<Question> uniqueQuestions = [];
            while (uniqueQuestions.Count < numberOfQuestions)
            {
                Random r = new Random();
                int max = questions.MaxBy(q => q.Id).Id;
                int min = questions.MinBy(q => q.Id).Id;

                Question uniqueQuestion = questions.FirstOrDefault(q => q.Id == r.Next(min, max + 1),new Question { Id = -1});
                if (!uniqueQuestions.Contains(uniqueQuestion))
                {
                    uniqueQuestions.Add(uniqueQuestion);
                    questions.Remove(uniqueQuestion);
                }
            }
            return uniqueQuestions;
        }
    }
}
