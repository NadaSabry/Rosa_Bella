using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rosa_Bella.Migrations
{
    public partial class add_season_class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Season",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "SeasonID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SeasonID",
                table: "Products",
                column: "SeasonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Seasons_SeasonID",
                table: "Products",
                column: "SeasonID",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Seasons_SeasonID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Products_SeasonID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SeasonID",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "Season",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
