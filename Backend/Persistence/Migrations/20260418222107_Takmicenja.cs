using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Takmicenja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Takmicenje",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Naziv = table.Column<string>(type: "TEXT", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", nullable: false),
                    DatumOdrzavanja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PoOdeljenju = table.Column<bool>(type: "INTEGER", nullable: false),
                    Kategorija = table.Column<int>(type: "INTEGER", nullable: false),
                    KreatorId = table.Column<string>(type: "TEXT", nullable: false),
                    DozvoliNaziveEkipa = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaxBrojClanova = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takmicenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Takmicenje_AspNetUsers_KreatorId",
                        column: x => x.KreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ekipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Naziv = table.Column<string>(type: "TEXT", nullable: false),
                    TakmicenjeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ekipe_Takmicenje_TakmicenjeId",
                        column: x => x.TakmicenjeId,
                        principalTable: "Takmicenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClanoviEkipe",
                columns: table => new
                {
                    EkipaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    JeKreator = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanoviEkipe", x => new { x.Id, x.EkipaId });
                    table.ForeignKey(
                        name: "FK_ClanoviEkipe_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanoviEkipe_Ekipe_EkipaId",
                        column: x => x.EkipaId,
                        principalTable: "Ekipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClanoviEkipe_EkipaId",
                table: "ClanoviEkipe",
                column: "EkipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ekipe_TakmicenjeId",
                table: "Ekipe",
                column: "TakmicenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Takmicenje_KreatorId",
                table: "Takmicenje",
                column: "KreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanoviEkipe");

            migrationBuilder.DropTable(
                name: "Ekipe");

            migrationBuilder.DropTable(
                name: "Takmicenje");
        }
    }
}
