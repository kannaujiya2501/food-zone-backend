using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Zone.Migrations
{
    public partial class checks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "checkout");

            migrationBuilder.CreateTable(
                name: "check",
                columns: table => new
                {
                    checkid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(maxLength: 30, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 50, nullable: true),
                    mobile = table.Column<string>(maxLength: 50, nullable: true),
                    state = table.Column<string>(maxLength: 50, nullable: true),
                    zip = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_check", x => x.checkid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "check");

            migrationBuilder.CreateTable(
                name: "checkout",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fullname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    zip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkout", x => x.id);
                });
        }
    }
}
