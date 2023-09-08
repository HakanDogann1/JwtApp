using JwtApp.API.Persistance.Context;
using JwtApp.API.Persistance.Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtApp.API.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtContext _context;

        public Repository(JwtContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
             _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            var values = await _context.Set<T>().AsNoTracking().ToListAsync();
            return values;
        }

        public async Task<T?> GetByFilter(Expression<Func<T?, bool>> filter)
        {
            var value = await _context.Set<T>().SingleOrDefaultAsync(filter);
            return value;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            return value;
        }

        public async Task UpdateAsync(T entity)
        {
             _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
