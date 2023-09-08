using System.Linq.Expressions;

namespace JwtApp.API.Persistance.Core.Application.Interfaces
{
    public interface IRepository<T> where T : class , new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByFilter(Expression<Func<T?, bool>> filter);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
