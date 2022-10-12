using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rosa_Bella.Migrations
{
    public partial class add_season : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Seasons_SeasonID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SeasonID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SeasonID",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
