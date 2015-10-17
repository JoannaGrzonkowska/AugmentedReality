using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessDenormalized.Repository
{
    public class Repository<TModel, TContext> : IRepository<TModel>
       where TModel : class
       where TContext : DbContext
    {
        protected readonly TContext Context;

        public Repository(TContext context)
        {
            Context = context;
        }

        public virtual TModel GetById(int id)
        {
            return Context.Set<TModel>().Find(id);
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            return Context.Set<TModel>().ToList();
        }

        public virtual IQueryable<TModel> GetAllQueryable()
        {
            return Context.Set<TModel>();
        }

        public virtual void Add(TModel entity)
        {
            Context.Set<TModel>().Add(entity);
        }

        public virtual void Delete(TModel entity)
        {
            Context.Set<TModel>().Remove(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        
    }
}
