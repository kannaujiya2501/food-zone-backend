using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Zone.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_name = table.Column<string>(maxLength: 30, nullable: true),
                    price = table.Column<string>(maxLength: 50, nullable: true),
                    quantity = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "famousdish",
                columns: table => new
                {
                    food_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    food_name = table.Column<string>(maxLength: 30, nullable: true),
                    price = table.Column<string>(maxLength: 50, nullable: true),
                    category = table.Column<string>(maxLength: 50, nullable: true),
                    image_url = table.Column<string>(maxLength: 50, nullable: true),
                    order_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_famousdish", x => x.food_id);
                    table.ForeignKey(
                        name: "FK_famousdish_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_famousdish_order_id",
                table: "famousdish",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "famousdish");

            migrationBuilder.DropTable(
                name: "order");
        }
    }
}
