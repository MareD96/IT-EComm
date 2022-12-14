// <auto-generated />
using System;
using IT_EComm.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IT_EComm.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221101225922_addedUserTable")]
    partial class addedUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IT_EComm.Models.Laptop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("CPUSpeed")
                        .HasColumnType("float");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DDR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraphicCardBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GraphicCardMemory")
                        .HasColumnType("int");

                    b.Property<string>("GraphicCardModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Inchs")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProcessorBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessorModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessorNoCores")
                        .HasColumnType("int");

                    b.Property<int>("RAMMemory")
                        .HasColumnType("int");

                    b.Property<string>("Resolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StorageSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Laptops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Dell",
                            Color = "Black",
                            DDR = "DDR4",
                            GraphicCardBrand = "Nvidia",
                            GraphicCardMemory = 2,
                            GraphicCardModel = "GeForce MX350",
                            Model = "Vostro 3510",
                            OS = "Linux",
                            Price = 600.0,
                            ProcessorBrand = "Intel",
                            ProcessorModel = "i5-1135G7",
                            RAMMemory = 8,
                            Storage = "SSD",
                            StorageSize = 256
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Accer",
                            Color = "Grey",
                            DDR = "DDR4",
                            GraphicCardBrand = "AMD",
                            GraphicCardModel = "Radeon RX Vega 6",
                            Model = "Aspire 5 A515-45 NX.A84EX.00A",
                            OS = "NA",
                            Price = 500.0,
                            ProcessorBrand = "AMD",
                            ProcessorModel = "Lucienne Ryzen 3 5300U",
                            RAMMemory = 8,
                            Storage = "SSD",
                            StorageSize = 256
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Lenovo",
                            Color = "Grey",
                            DDR = "DDR4",
                            GraphicCardBrand = "Intel",
                            GraphicCardModel = "Intel UHD",
                            Model = "Vostro 3510",
                            OS = "Windows",
                            Price = 600.0,
                            ProcessorBrand = "Intel",
                            ProcessorModel = "i5-1135G7",
                            RAMMemory = 8,
                            Storage = "SSD",
                            StorageSize = 256
                        });
                });

            modelBuilder.Entity("IT_EComm.Models.LaptopImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LaptopId")
                        .HasColumnType("int");

                    b.Property<string>("Paths")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LaptopId");

                    b.ToTable("ImagesLaptops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageURL = "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/vostro-notebooks/15-3510/media-gallery/archive/dv3510nt_cnb_00000ff090_bk.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=402&qlt=100,1&resMode=sharp2&size=402,402&chrss=full",
                            LaptopId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImageURL = "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/vostro-notebooks/15-3510/media-gallery/archive/dv3510nt_cnb_00055rf110_bk.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=402&qlt=100,1&resMode=sharp2&size=402,402&chrss=full",
                            LaptopId = 1
                        },
                        new
                        {
                            Id = 3,
                            ImageURL = "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/vostro-notebooks/15-3510/media-gallery/archive/dv3510nt_cnb_00180bf090_bk.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=402&qlt=100,1&resMode=sharp2&size=402,402&chrss=full",
                            LaptopId = 1
                        },
                        new
                        {
                            Id = 4,
                            ImageURL = "https://img.gigatron.rs/img/products/large/ACER-Aspire-5-A515-45-NX.A84EX.00A-64.png",
                            LaptopId = 2
                        },
                        new
                        {
                            Id = 5,
                            ImageURL = "https://img.gigatron.rs/img/products/large/image61e58adf23222.png",
                            LaptopId = 3
                        });
                });

            modelBuilder.Entity("IT_EComm.Models.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IT_EComm.Models.LaptopImages", b =>
                {
                    b.HasOne("IT_EComm.Models.Laptop", "Laptop")
                        .WithMany()
                        .HasForeignKey("LaptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop");
                });
#pragma warning restore 612, 618
        }
    }
}
