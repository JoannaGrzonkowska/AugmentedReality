using System;

namespace CQRS.Commands
{
    public abstract class Command<TEntity> : ICommand
    {
        public int Id { get; private set; }

        public abstract TEntity Build(TEntity entity, Action<TEntity> action = null);
    }
}
