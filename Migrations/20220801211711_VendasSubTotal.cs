using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasTamboril.Migrations
{
    public partial class VendasSubTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Sales",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Sales");
        }
    }
}
