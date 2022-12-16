using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Zone.Migrations
{
    public partial class nonveg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "famousdish");

            migrationBuilder.CreateTable(
                name: "nonveg",
                columns: table => new
                {
                    food_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    food_name = table.Column<string>(maxLength: 30, nullable: true),
                    price = table.Column<string>(maxLength: 50, nullable: true),
                    image_url = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nonveg", x => x.food_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nonveg");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "famousdish",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
