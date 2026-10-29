using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoServiz.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ugyfel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugyfel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Javitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UgyfelId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rendszam = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Leiras = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    Koltseg = table.Column<int>(type: "INTEGER", nullable: false),
                    Allapot = table.Column<string>(type: "TEXT", nullable: false),
                    FelvetelDatuma = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Javitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Javitas_Ugyfel_UgyfelId",
                        column: x => x.UgyfelId,
                        principalTable: "Ugyfel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Javitas_UgyfelId",
                table: "Javitas",
                column: "UgyfelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Javitas");

            migrationBuilder.DropTable(
                name: "Ugyfel");
        }
    }
}
