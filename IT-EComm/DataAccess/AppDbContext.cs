using IT_EComm.Helpers;
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
        public DbSet<LaptopImages> ImagesLaptops { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Laptop>().HasData
                (
                new Laptop
                {
                    Id = 1,
                    Brand = Utility.LaptopBrands.Dell.ToString(),
                    Model = "Vostro 3510",
                    Price = 600,
                    RAMMemory = 8,
                    DDR = Utility.DDR.DDR4.ToString(),

                    GraphicCardBrand = Utility.Brands.Nvidia.ToString(),
                    GraphicCardModel = "GeForce MX350",
                    GraphicCardMemory = 2,
                    Color = "Black",

                    ProcessorBrand = Utility.Brands.Intel.ToString(),
                    ProcessorModel = "i5-1135G7",

                    Storage=Utility.Storage.SSD.ToString(),
                    StorageSize=256,

                    OS=Utility.OS.Linux.ToString()
                },
                new Laptop
                {
                    Id = 2,
                    Brand = Utility.LaptopBrands.Accer.ToString(),
                    Model = "Aspire 5 A515-45 NX.A84EX.00A",
                    Price = 500,
                    RAMMemory = 8,
                    DDR = Utility.DDR.DDR4.ToString(),

                    GraphicCardBrand = Utility.Brands.AMD.ToString(),
                    GraphicCardModel = "Radeon RX Vega 6",
                    Color = "Grey",

                    ProcessorBrand = Utility.Brands.AMD.ToString(),
                    ProcessorModel = "Lucienne Ryzen 3 5300U",

                    Storage = Utility.Storage.SSD.ToString(),
                    StorageSize = 256,

                    OS = Utility.OS.NA.ToString()
                },
                new Laptop
                {
                    Id = 3,
                    Brand = Utility.LaptopBrands.Lenovo.ToString(),
                    Model = "Vostro 3510",
                    Price = 600,
                    RAMMemory = 8,
                    DDR = Utility.DDR.DDR4.ToString(),

                    GraphicCardBrand = Utility.Brands.Intel.ToString(),
                    GraphicCardModel = "Intel UHD",
                    Color = "Grey",

                    ProcessorBrand = Utility.Brands.Intel.ToString(),
                    ProcessorModel = "i5-1135G7",

                    Storage = Utility.Storage.SSD.ToString(),
                    StorageSize = 256,

                    OS = Utility.OS.Windows.ToString()
                }
                ) ;
        }

    }
}
