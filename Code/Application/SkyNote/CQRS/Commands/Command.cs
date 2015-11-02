using System;

namespace CQRS.Commands
{
    public class Command<TEntity> : ICommand where TEntity: new()
    {
        public int Id { get; private set; }

        public virtual TEntity Build(TEntity entity, Action<TEntity> action = null)
        {
            if (entity == null)
            {
                entity = new TEntity();
            }

            if (action != null)
            {
                action(entity);
            }
            return entity;
        }
    }
}
