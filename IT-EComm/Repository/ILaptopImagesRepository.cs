using IT_EComm.Models;
using System.Linq.Expressions;

namespace IT_EComm.Repository
{
    public interface ILaptopImagesRepository:IRepository<LaptopImages>
    {
        Task<LaptopImages> UpdateAsync(LaptopImages laptopImages);
        Task<List<LaptopImages>> GetLapTopImages(int laptopId);
    }
}
