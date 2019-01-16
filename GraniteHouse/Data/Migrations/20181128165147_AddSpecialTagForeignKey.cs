using Microsoft.EntityFrameworkCore.Migrations;

namespace GraniteHouse.Data.Migrations
{
    public partial class AddSpecialTagForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialTagID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialTagsID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SpecialTagsID",
                table: "Products",
                column: "SpecialTagsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SpecialsTags_SpecialTagsID",
                table: "Products",
                column: "SpecialTagsID",
                principalTable: "SpecialsTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SpecialsTags_SpecialTagsID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SpecialTagsID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpecialTagID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpecialTagsID",
                table: "Products");
        }
    }
}
