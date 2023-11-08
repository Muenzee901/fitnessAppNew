using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fitness.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PleaseWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainingsplaene",
                columns: table => new
                {
                    TrainingsplanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainingsplaene", x => x.TrainingsplanId);
                });

            migrationBuilder.CreateTable(
                name: "Uebungen",
                columns: table => new
                {
                    UebungId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ausfuehrung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Muskelgruppe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uebungen", x => x.UebungId);
                });

            migrationBuilder.CreateTable(
                name: "GeplanteUebungen",
                columns: table => new
                {
                    GeplanteUebungId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingsplanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UebungId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnzahlSaetze = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeplanteUebungen", x => x.GeplanteUebungId);
                    table.ForeignKey(
                        name: "FK_GeplanteUebungen_Trainingsplaene_TrainingsplanId",
                        column: x => x.TrainingsplanId,
                        principalTable: "Trainingsplaene",
                        principalColumn: "TrainingsplanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeplanteUebungen_Uebungen_UebungId",
                        column: x => x.UebungId,
                        principalTable: "Uebungen",
                        principalColumn: "UebungId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trainingsplaene",
                columns: new[] { "TrainingsplanId", "Name" },
                values: new object[] { new Guid("3cf8b422-e92d-487b-8d4e-97a3e0e711a7"), "Testplan" });

            migrationBuilder.InsertData(
                table: "Uebungen",
                columns: new[] { "UebungId", "Ausfuehrung", "Muskelgruppe", "Name" },
                values: new object[,]
                {
                    { new Guid("850e6ccb-f0eb-41f8-8725-0238521a6cf6"), "Muss anders gemacht werden", 0, "Butterfly" },
                    { new Guid("b00f32df-fb45-4bbc-bfcf-ea4c40f565f5"), "Muss wieder anders gemacht werden", 1, "BizepsCurl" },
                    { new Guid("fc52460c-790d-4f11-b5e8-d79a1657961a"), "Muss so gemacht werden", 3, "ButterflyReverse" }
                });

            migrationBuilder.InsertData(
                table: "GeplanteUebungen",
                columns: new[] { "GeplanteUebungId", "AnzahlSaetze", "TrainingsplanId", "UebungId" },
                values: new object[,]
                {
                    { new Guid("6e26bfb3-1e32-489f-a701-731c6cc771b1"), 3, new Guid("3cf8b422-e92d-487b-8d4e-97a3e0e711a7"), new Guid("b00f32df-fb45-4bbc-bfcf-ea4c40f565f5") },
                    { new Guid("72f4b931-447c-48fa-9521-bdc0bb7471f7"), 3, new Guid("3cf8b422-e92d-487b-8d4e-97a3e0e711a7"), new Guid("fc52460c-790d-4f11-b5e8-d79a1657961a") },
                    { new Guid("e479563f-f3a9-439b-bac9-b662b450fb18"), 4, new Guid("3cf8b422-e92d-487b-8d4e-97a3e0e711a7"), new Guid("850e6ccb-f0eb-41f8-8725-0238521a6cf6") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeplanteUebungen_TrainingsplanId",
                table: "GeplanteUebungen",
                column: "TrainingsplanId");

            migrationBuilder.CreateIndex(
                name: "IX_GeplanteUebungen_UebungId",
                table: "GeplanteUebungen",
                column: "UebungId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeplanteUebungen");

            migrationBuilder.DropTable(
                name: "Trainingsplaene");

            migrationBuilder.DropTable(
                name: "Uebungen");
        }
    }
}
