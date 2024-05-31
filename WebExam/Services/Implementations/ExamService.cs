using WebExam.DataAccess.Repositories.Interfaces;
using WebExam.Entity.Implementations;
using WebExam.Mappers.Interfaces;
using WebExam.Models.Implementations;
using WebExam.Services.Interfaces;

namespace WebExam.Services.Implementations
{
    public class ExamService(IUnitOfWork repository) : IExamService
    {
        public List<Exam> Get() => repository.ExamRepository.Get();
        public Exam Get(int modelId) => repository.ExamRepository.Get(modelId);
        public int Insert(Exam model) => repository.ExamRepository.Insert(model);
        public bool Update(Exam model) => repository.ExamRepository.Update(model);
        public bool Delete(int modelId) => repository.ExamRepository.Delete(modelId);
    }
}
