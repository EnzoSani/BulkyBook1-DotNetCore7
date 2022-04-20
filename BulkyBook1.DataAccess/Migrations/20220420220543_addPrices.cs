using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb1.Migrations
{
    public partial class addPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListPrice50",
                table: "Products",
                newName: "Price50");

            migrationBuilder.RenameColumn(
                name: "ListPrice100",
                table: "Products",
                newName: "Price100");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Price50",
                table: "Products",
                newName: "ListPrice50");

            migrationBuilder.RenameColumn(
                name: "Price100",
                table: "Products",
                newName: "ListPrice100");
        }
    }
}
