using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class izmjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_predmets_ocjenas_ocjenaID",
                table: "predmets");

            migrationBuilder.DropForeignKey(
                name: "FK_predmets_students_studentID",
                table: "predmets");

            migrationBuilder.DropIndex(
                name: "IX_predmets_ocjenaID",
                table: "predmets");

            migrationBuilder.DropIndex(
                name: "IX_predmets_studentID",
                table: "predmets");

            migrationBuilder.DropColumn(
                name: "ocjenaID",
                table: "predmets");

            migrationBuilder.DropColumn(
                name: "studentID",
                table: "predmets");

            migrationBuilder.CreateTable(
                name: "predmetOcjenas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ocjenaID = table.Column<int>(nullable: false),
                    predmetID = table.Column<int>(nullable: false),
                    studentID = table.Column<int>(nullable: false),
                    datum_polaganja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predmetOcjenas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_predmetOcjenas_ocjenas_ocjenaID",
                        column: x => x.ocjenaID,
                        principalTable: "ocjenas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_predmetOcjenas_predmets_predmetID",
                        column: x => x.predmetID,
                        principalTable: "predmets",
                        principalColumn: "predmetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_predmetOcjenas_students_studentID",
                        column: x => x.studentID,
                        principalTable: "students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_predmetOcjenas_ocjenaID",
                table: "predmetOcjenas",
                column: "ocjenaID");

            migrationBuilder.CreateIndex(
                name: "IX_predmetOcjenas_predmetID",
                table: "predmetOcjenas",
                column: "predmetID");

            migrationBuilder.CreateIndex(
                name: "IX_predmetOcjenas_studentID",
                table: "predmetOcjenas",
                column: "studentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "predmetOcjenas");

            migrationBuilder.AddColumn<int>(
                name: "ocjenaID",
                table: "predmets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "studentID",
                table: "predmets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_predmets_ocjenaID",
                table: "predmets",
                column: "ocjenaID");

            migrationBuilder.CreateIndex(
                name: "IX_predmets_studentID",
                table: "predmets",
                column: "studentID");

            migrationBuilder.AddForeignKey(
                name: "FK_predmets_ocjenas_ocjenaID",
                table: "predmets",
                column: "ocjenaID",
                principalTable: "ocjenas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_predmets_students_studentID",
                table: "predmets",
                column: "studentID",
                principalTable: "students",
                principalColumn: "studentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
