
namespace CQRS.Implementation.Models
{
    public abstract class BaseDTO<TEntity> where TEntity : new()
    {
        public abstract BaseDTO<TEntity> BuildDTO(TEntity entity);
    }
}
