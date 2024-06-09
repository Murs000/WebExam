using WebExam.Entity.Implementations;

namespace WebExam.DataAccess.Repositorys.Interfaces
{
    public interface IChoiseRepository : IRepository<Choise>
    {
        public List<Choise> GetByQuestion(int questionId);
    }
}
