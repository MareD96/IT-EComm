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


        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includeProperties!=null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? expression = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (expression!=null)
            {
                query = query.Where(expression);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await SaveAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
             _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
