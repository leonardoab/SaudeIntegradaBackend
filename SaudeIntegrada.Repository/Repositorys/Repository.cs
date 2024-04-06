
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SaudeIntegrada.Repository.Context;
using SaudeIntegrada.Repository.IRepositorys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SaudeIntegrada.Repository.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public Repository(SaudeIntegradaContext context)
        {
            Context = context;
            Query = Context.Set<T>();
        }

        public async Task Save(T entity)
        {
            await Query.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Query.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            Query.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<T> Get(object id)
        {
            return await Query.FindAsync(id);
        }

        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
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