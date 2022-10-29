using IT_EComm.DataAccess;
using IT_EComm.Models;

namespace IT_EComm.Repository
{
    public class LaptopRepository : Repository<Laptop>, ILaptopRepository
    {
        private readonly AppDbContext _dbContext;
        public LaptopRepository(AppDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Laptop> UpdateAsync(Laptop laptop)
        {
            _dbContext.Update(laptop);
            await _dbContext.SaveChangesAsync();
            return laptop;
        }
    }
}
