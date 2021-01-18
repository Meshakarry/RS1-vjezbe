using Microsoft.EntityFrameworkCore.Migrations;

namespace Podaci.Migrations
{
    public partial class inicijala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fakultets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fakultets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ocjenas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ocjena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ocjenas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "opstinas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_opstinas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    studentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Br_Ind = table.Column<string>(nullable: true),
                    opstinaID = table.Column<int>(nullable: false),
                    fakultetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.studentID);
                    table.ForeignKey(
                        name: "FK_students_fakultets_fakultetID",
                        column: x => x.fakultetID,
                        principalTable: "fakultets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_students_opstinas_opstinaID",
                        column: x => x.opstinaID,
                        principalTable: "opstinas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "predmets",
                columns: table => new
                {
                    predmetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    ocjenaID = table.Column<int>(nullable: false),
                    studentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predmets", x => x.predmetID);
                    table.ForeignKey(
                        name: "FK_predmets_ocjenas_ocjenaID",
                        column: x => x.ocjenaID,
                        principalTable: "ocjenas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_predmets_students_studentID",
                        column: x => x.studentID,
                        principalTable: "students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_predmets_ocjenaID",
                table: "predmets",
                column: "ocjenaID");

            migrationBuilder.CreateIndex(
                name: "IX_predmets_studentID",
                table: "predmets",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_students_fakultetID",
                table: "students",
                column: "fakultetID");

            migrationBuilder.CreateIndex(
                name: "IX_students_opstinaID",
                table: "students",
                column: "opstinaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "predmets");

            migrationBuilder.DropTable(
                name: "ocjenas");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "fakultets");

            migrationBuilder.DropTable(
                name: "opstinas");
        }
    }
}
