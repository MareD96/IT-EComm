using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_EComm.Migrations
{
    public partial class changeOSColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OS",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 1,
                column: "OS",
                value: "Linux");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 2,
                column: "OS",
                value: "NA");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 3,
                column: "OS",
                value: "Windows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OS",
                table: "Laptops",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 1,
                column: "OS",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 2,
                column: "OS",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: 3,
                column: "OS",
                value: 1);
        }
    }
}
