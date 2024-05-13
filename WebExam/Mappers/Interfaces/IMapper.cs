using WebExam.Entity.Interfaces;
using WebExam.Models.Interfaces;

namespace WebExam.Mappers.Interfaces
{
    public interface IMapper<TEntity, TModel> where TEntity : IEntity
                                                 where TModel : IApiModel, new()
    {
        TModel Map(TEntity entity);
        TEntity Map(TModel model);
        List<TModel> Map(List<TEntity> entity);
        List<TEntity> Map(List<TModel> model);
    }
}
