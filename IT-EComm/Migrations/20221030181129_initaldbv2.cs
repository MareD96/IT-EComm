using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_EComm.Migrations
{
    public partial class initaldbv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BluetoothNo",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "ImageURl",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "LAN",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "UsbCNo",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "WebCam",
                table: "Laptops");

            migrationBuilder.RenameColumn(
                name: "WiFi",
                table: "Laptops",
                newName: "DDR");

            migrationBuilder.AlterColumn<string>(
                name: "Storage",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Resolution",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessorNoCores",
                table: "Laptops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessorBrand",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Inchs",
                table: "Laptops",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "GraphicCardMemory",
                table: "Laptops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GraphicCardBrand",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "CPUSpeed",
                table: "Laptops",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "CPUSpeed", "Color", "DDR", "Description", "GraphicCardBrand", "GraphicCardMemory", "GraphicCardModel", "Inchs", "Model", "OS", "Price", "ProcessorBrand", "ProcessorModel", "ProcessorNoCores", "RAMMemory", "Resolution", "Storage", "StorageSize" },
                values: new object[] { 1, "Dell", null, "Black", "DDR4", null, "Nvidia", 2, "GeForce MX350", null, "Vostro 3510", 2, 600.0, "Intel", "i5-1135G7", null, 8, null, "SSD", 256 });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "CPUSpeed", "Color", "DDR", "Description", "GraphicCardBrand", "GraphicCardMemory", "GraphicCardModel", "Inchs", "Model", "OS", "Price", "ProcessorBrand", "ProcessorModel", "ProcessorNoCores", "RAMMemory", "Resolution", "Storage", "StorageSize" },
                values: new object[] { 2, "Accer", null, "Grey", "DDR4", null, "AMD", null, "Radeon RX Vega 6", null, "Aspire 5 A515-45 NX.A84EX.00A", 4, 500.0, "AMD", "Lucienne Ryzen 3 5300U", null, 8, null, "SSD", 256 });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "CPUSpeed", "Color", "DDR", "Description", "GraphicCardBrand", "GraphicCardMemory", "GraphicCardModel", "Inchs", "Model", "OS", "Price", "ProcessorBrand", "ProcessorModel", "ProcessorNoCores", "RAMMemory", "Resolution", "Storage", "StorageSize" },
                values: new object[] { 3, "Lenovo", null, "Grey", "DDR4", null, "Intel", null, "Intel UHD", null, "Vostro 3510", 1, 600.0, "Intel", "i5-1135G7", null, 8, null, "SSD", 256 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Laptops");

            migrationBuilder.RenameColumn(
                name: "DDR",
                table: "Laptops",
                newName: "WiFi");

            migrationBuilder.AlterColumn<int>(
                name: "Storage",
                table: "Laptops",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Resolution",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessorNoCores",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProcessorBrand",
                table: "Laptops",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Inchs",
                table: "Laptops",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GraphicCardMemory",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GraphicCardBrand",
                table: "Laptops",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "CPUSpeed",
                table: "Laptops",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BluetoothNo",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURl",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LAN",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsbCNo",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WebCam",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
