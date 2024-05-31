using WebExam.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace WebExam.Services.Interfaces
{
    public interface IService<T> 
    {
        List<T> Get();
        T Get(int modelId);
        int Insert(T model);
        bool Update(T model);
        bool Delete(int modelId);
    }
}
