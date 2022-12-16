using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Zone.Migrations
{
    public partial class gallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gallery",
                columns: table => new
                {
                    food_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    food_name = table.Column<string>(maxLength: 30, nullable: true),
                    image_url = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gallery", x => x.food_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gallery");
        }
    }
}
