using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace SaudeIntegrada.Repository.IRepositorys
{
    public interface IRepository<T> where T : class
    {
        Task Delete(T entity);

        Task<T> Get(object id);

        Task Save(T entity);

        Task Update(T entity);

        IEnumerable<T> GetAll();

        T GetById(Guid id);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        bool Exists(Expression<Func<T, bool>> expression);
      
    }
}