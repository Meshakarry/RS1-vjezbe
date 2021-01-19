using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class prisustvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "prisustvoNaNastavis",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentID = table.Column<int>(nullable: false),
                    predmetID = table.Column<int>(nullable: false),
                    datum_prisustva = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prisustvoNaNastavis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_prisustvoNaNastavis_predmets_predmetID",
                        column: x => x.predmetID,
                        principalTable: "predmets",
                        principalColumn: "predmetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prisustvoNaNastavis_students_studentID",
                        column: x => x.studentID,
                        principalTable: "students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prisustvoNaNastavis_predmetID",
                table: "prisustvoNaNastavis",
                column: "predmetID");

            migrationBuilder.CreateIndex(
                name: "IX_prisustvoNaNastavis_studentID",
                table: "prisustvoNaNastavis",
                column: "studentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prisustvoNaNastavis");
        }
    }
}
