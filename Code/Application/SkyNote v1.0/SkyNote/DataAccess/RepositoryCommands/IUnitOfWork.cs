using System;

namespace DataAccess.RepositoryCommands
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
