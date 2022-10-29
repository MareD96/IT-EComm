using IT_EComm.Models;

namespace IT_EComm.Repository
{
    public interface ILaptopRepository:IRepository<Laptop>
    {
        Task<Laptop> UpdateAsync(Laptop laptop);
    }
}
