using Microsoft.EntityFrameworkCore.Migrations;

namespace Food_Zone.Migrations
{
    public partial class contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_famousdish_order_order_id",
                table: "famousdish");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropIndex(
                name: "IX_famousdish_order_id",
                table: "famousdish");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "famousdish");

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    contactid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 30, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: true),
                    message = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.contactid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "famousdish",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grandtotal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    order_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    price = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    quantity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    total = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.order_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_famousdish_order_id",
                table: "famousdish",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_famousdish_order_order_id",
                table: "famousdish",
                column: "order_id",
                principalTable: "order",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
