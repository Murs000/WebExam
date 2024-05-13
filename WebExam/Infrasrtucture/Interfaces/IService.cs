using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace WebExam.Infrasrtucture.Interfaces
{
    public interface IService<T> where T : IApiModel
    {
        List<T> Get();
        T Get(int modelId);
        int Insert(T model);
        bool Update(T model);
        bool Delete(int modelId);
    }
}
