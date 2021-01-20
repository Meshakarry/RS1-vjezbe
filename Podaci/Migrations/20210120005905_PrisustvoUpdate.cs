using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class PrisustvoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrisutan",
                table: "prisustvoNaNastavis",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "komentar",
                table: "prisustvoNaNastavis",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrisutan",
                table: "prisustvoNaNastavis");

            migrationBuilder.DropColumn(
                name: "komentar",
                table: "prisustvoNaNastavis");
        }
    }
}
