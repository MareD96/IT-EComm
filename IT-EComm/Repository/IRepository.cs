using IT_EComm.Models;
using System.Linq.Expressions;

namespace IT_EComm.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null,string? includeProperties=null);
        Task<T> GetAsync(Expression<Func<T, bool>>? expression = null, string? includeProperties=null);
        Task CreateAsync(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
