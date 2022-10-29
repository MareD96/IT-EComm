using IT_EComm.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IT_EComm.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet=_dbContext.Set<T>();
        }


        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? expression = null)
        {
            IQueryable<T> query = dbSet;
            if (expression!=null)
            {
                query = query.Where(expression);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            _dbContext.AddAsync(entity);
            await SaveAsync();
        }

        public async void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChangesAsync().GetAwaiter();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
