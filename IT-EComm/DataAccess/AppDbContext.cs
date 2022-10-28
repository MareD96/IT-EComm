using IT_EComm.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_EComm.DataAccess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {

        }

        public DbSet<Laptop> Laptops{ get; set; }


    }
}
