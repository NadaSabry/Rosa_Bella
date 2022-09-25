using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rosa_Bella.Migrations
{
    public partial class add_MainCategory_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoyImageUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainCategorysId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainCategoyID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Season",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MainCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoyImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategorys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategorysId",
                table: "Categories",
                column: "MainCategorysId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MainCategorys_MainCategorysId",
                table: "Categories",
                column: "MainCategorysId",
                principalTable: "MainCategorys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MainCategorys_MainCategorysId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "MainCategorys");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MainCategorysId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoyImageUrl",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MainCategorysId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MainCategoyID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Categories");
        }
    }
}
