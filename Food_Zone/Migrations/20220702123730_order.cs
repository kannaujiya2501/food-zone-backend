using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Zone.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "grandtotal",
                table: "order",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "total",
                table: "order",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "grandtotal",
                table: "order");

            migrationBuilder.DropColumn(
                name: "total",
                table: "order");
        }
    }
}
