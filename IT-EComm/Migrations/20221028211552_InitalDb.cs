using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_EComm.Migrations
{
    public partial class InitalDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RAMMemory = table.Column<int>(type: "int", nullable: false),
                    GraphicCardBrand = table.Column<int>(type: "int", nullable: false),
                    GraphicCardModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraphicCardMemory = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessorBrand = table.Column<int>(type: "int", nullable: false),
                    ProcessorModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessorNoCores = table.Column<int>(type: "int", nullable: false),
                    CPUSpeed = table.Column<double>(type: "float", nullable: false),
                    Storage = table.Column<int>(type: "int", nullable: false),
                    StorageSize = table.Column<int>(type: "int", nullable: false),
                    OS = table.Column<int>(type: "int", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inchs = table.Column<double>(type: "float", nullable: false),
                    WebCam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WiFi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BluetoothNo = table.Column<int>(type: "int", nullable: false),
                    UsbCNo = table.Column<int>(type: "int", nullable: false),
                    ImageURl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptops");
        }
    }
}
