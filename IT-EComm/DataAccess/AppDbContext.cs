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
        public DbSet<LocalUser> User { get; set; }
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

            modelBuilder.Entity<LaptopImages>().HasData
                (
                new LaptopImages
                {
                    Id=1,
                    LaptopId=1,
                    ImageURL= "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/vostro-notebooks/15-3510/media-gallery/archive/dv3510nt_cnb_00000ff090_bk.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=402&qlt=100,1&resMode=sharp2&size=402,402&chrss=full"
                },
                new LaptopImages
                {
                    Id = 2,
                    LaptopId = 1,
                    ImageURL = "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/vostro-notebooks/15-3510/media-gallery/archive/dv3510nt_cnb_00055rf110_bk.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=402&qlt=100,1&resMode=sharp2&size=402,402&chrss=full"
                },
                new LaptopImages
                {
                    Id=3,
                    LaptopId=1,
                    ImageURL= "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/vostro-notebooks/15-3510/media-gallery/archive/dv3510nt_cnb_00180bf090_bk.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=402&qlt=100,1&resMode=sharp2&size=402,402&chrss=full"
                },


                new LaptopImages
                {
                    Id=4,
                    LaptopId=2,
                    ImageURL= "https://img.gigatron.rs/img/products/large/ACER-Aspire-5-A515-45-NX.A84EX.00A-64.png"
                },


                new LaptopImages
                {
                    Id=5,
                    LaptopId=3,
                    ImageURL= "https://img.gigatron.rs/img/products/large/image61e58adf23222.png"

                }
                );
        }

    }
}
