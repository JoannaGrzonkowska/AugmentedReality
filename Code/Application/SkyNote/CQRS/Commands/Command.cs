using System;

namespace CQRS.Commands
{
    public class Command<TEntity> : ICommand where TEntity: new()
    {
        public int Id { get; set; }
        public int Authentication_UserId { get; set; }
        public string Authentication_UserName { get; set; }

        public bool CanBeAuthenticated()
        {
            if (Authentication_UserId>0 || Authentication_UserName != null)
                return true;
            return false;
        }

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
