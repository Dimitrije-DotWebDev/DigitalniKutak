using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Takmicenja1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ekipe_Takmicenje_TakmicenjeId",
                table: "Ekipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Takmicenje_AspNetUsers_KreatorId",
                table: "Takmicenje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Takmicenje",
                table: "Takmicenje");

            migrationBuilder.RenameTable(
                name: "Takmicenje",
                newName: "Takmicenja");

            migrationBuilder.RenameIndex(
                name: "IX_Takmicenje_KreatorId",
                table: "Takmicenja",
                newName: "IX_Takmicenja_KreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Takmicenja",
                table: "Takmicenja",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ekipe_Takmicenja_TakmicenjeId",
                table: "Ekipe",
                column: "TakmicenjeId",
                principalTable: "Takmicenja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Takmicenja_AspNetUsers_KreatorId",
                table: "Takmicenja",
                column: "KreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ekipe_Takmicenja_TakmicenjeId",
                table: "Ekipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Takmicenja_AspNetUsers_KreatorId",
                table: "Takmicenja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Takmicenja",
                table: "Takmicenja");

            migrationBuilder.RenameTable(
                name: "Takmicenja",
                newName: "Takmicenje");

            migrationBuilder.RenameIndex(
                name: "IX_Takmicenja_KreatorId",
                table: "Takmicenje",
                newName: "IX_Takmicenje_KreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Takmicenje",
                table: "Takmicenje",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ekipe_Takmicenje_TakmicenjeId",
                table: "Ekipe",
                column: "TakmicenjeId",
                principalTable: "Takmicenje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Takmicenje_AspNetUsers_KreatorId",
                table: "Takmicenje",
                column: "KreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
