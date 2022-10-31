using IT_EComm.DataAccess;
using IT_EComm.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IT_EComm.Repository
{
    public class LaptopImagesRepository:Repository<LaptopImages>,ILaptopImagesRepository
    {
        private readonly AppDbContext _appDb;

        public LaptopImagesRepository(AppDbContext appDb):base(appDb)
        {
            _appDb = appDb;
        }

        public Task<List<LaptopImages>> GetLapTopImages(int laptopId)
        {
            var listOfImages = _appDb.ImagesLaptops.Where(u => u.LaptopId == laptopId).ToListAsync<LaptopImages>();
            return listOfImages;
        }

        public async Task<LaptopImages> UpdateAsync(LaptopImages laptopImages)
        {
            _appDb.Update(laptopImages);
            await _appDb.SaveChangesAsync();
            return laptopImages;
        }
    }
}
