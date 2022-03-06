using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2Linq.Migrations
{
    public partial class FirstCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klasser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    klassNamn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lärare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    förNamn = table.Column<string>(nullable: true),
                    efterNamn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lärare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elever",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    förNamn = table.Column<string>(nullable: true),
                    efterNamn = table.Column<string>(nullable: true),
                    KlassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elever", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elever_Klasser_KlassId",
                        column: x => x.KlassId,
                        principalTable: "Klasser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kurser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kursNamn = table.Column<string>(nullable: true),
                    LärareId = table.Column<int>(nullable: true),
                    KlassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurser_Klasser_KlassId",
                        column: x => x.KlassId,
                        principalTable: "Klasser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kurser_Lärare_LärareId",
                        column: x => x.LärareId,
                        principalTable: "Lärare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elever_KlassId",
                table: "Elever",
                column: "KlassId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_KlassId",
                table: "Kurser",
                column: "KlassId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_LärareId",
                table: "Kurser",
                column: "LärareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elever");

            migrationBuilder.DropTable(
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Klasser");

            migrationBuilder.DropTable(
                name: "Lärare");
        }
    }
}
