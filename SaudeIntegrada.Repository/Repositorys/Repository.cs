using SaudeIntegrada.Repository.Context;
using SaudeIntegrada.Repository.IRepositorys;
using System.Data;
using System.Linq.Expressions;

namespace SaudeIntegrada.Repository.Repositorys
{
    public abstract class Repository<T> : IRepository<T> where T : class, new()
    {
        private SaudeIntegradaContext Context { get; set; }

        public Repository(SaudeIntegradaContext Context)
        {
            this.Context = Context;
        }

        public void Save(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }
        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return Find(expression).Any();
        }




    }
}