using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2Linq.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elever_Klasser_KlassId",
                table: "Elever");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Klasser_KlassId",
                table: "Kurser");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Lärare_LärareId",
                table: "Kurser");

            migrationBuilder.DropIndex(
                name: "IX_Kurser_KlassId",
                table: "Kurser");

            migrationBuilder.DropIndex(
                name: "IX_Kurser_LärareId",
                table: "Kurser");

            migrationBuilder.DropIndex(
                name: "IX_Elever_KlassId",
                table: "Elever");

            migrationBuilder.DropColumn(
                name: "KlassId",
                table: "Kurser");

            migrationBuilder.DropColumn(
                name: "LärareId",
                table: "Kurser");

            migrationBuilder.DropColumn(
                name: "KlassId",
                table: "Elever");

            migrationBuilder.AddColumn<int>(
                name: "_KlassId",
                table: "Kurser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_LärareId",
                table: "Kurser",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_KlassId",
                table: "Elever",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kurser__KlassId",
                table: "Kurser",
                column: "_KlassId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurser__LärareId",
                table: "Kurser",
                column: "_LärareId");

            migrationBuilder.CreateIndex(
                name: "IX_Elever__KlassId",
                table: "Elever",
                column: "_KlassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elever_Klasser__KlassId",
                table: "Elever",
                column: "_KlassId",
                principalTable: "Klasser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurser_Klasser__KlassId",
                table: "Kurser",
                column: "_KlassId",
                principalTable: "Klasser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurser_Lärare__LärareId",
                table: "Kurser",
                column: "_LärareId",
                principalTable: "Lärare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elever_Klasser__KlassId",
                table: "Elever");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Klasser__KlassId",
                table: "Kurser");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurser_Lärare__LärareId",
                table: "Kurser");

            migrationBuilder.DropIndex(
                name: "IX_Kurser__KlassId",
                table: "Kurser");

            migrationBuilder.DropIndex(
                name: "IX_Kurser__LärareId",
                table: "Kurser");

            migrationBuilder.DropIndex(
                name: "IX_Elever__KlassId",
                table: "Elever");

            migrationBuilder.DropColumn(
                name: "_KlassId",
                table: "Kurser");

            migrationBuilder.DropColumn(
                name: "_LärareId",
                table: "Kurser");

            migrationBuilder.DropColumn(
                name: "_KlassId",
                table: "Elever");

            migrationBuilder.AddColumn<int>(
                name: "KlassId",
                table: "Kurser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LärareId",
                table: "Kurser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlassId",
                table: "Elever",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_KlassId",
                table: "Kurser",
                column: "KlassId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_LärareId",
                table: "Kurser",
                column: "LärareId");

            migrationBuilder.CreateIndex(
                name: "IX_Elever_KlassId",
                table: "Elever",
                column: "KlassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elever_Klasser_KlassId",
                table: "Elever",
                column: "KlassId",
                principalTable: "Klasser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurser_Klasser_KlassId",
                table: "Kurser",
                column: "KlassId",
                principalTable: "Klasser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurser_Lärare_LärareId",
                table: "Kurser",
                column: "LärareId",
                principalTable: "Lärare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
