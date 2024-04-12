using System.Linq.Expressions;

namespace SaudeIntegrada.Repository.IRepositorys
{
    public interface IRepository<T> where T : class, new()
    {
        void Delete(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Save(T entity);
        void Update(T entity);
    }
}