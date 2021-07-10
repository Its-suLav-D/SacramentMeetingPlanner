using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sacrament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conducting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningHymn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningPrayer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SacramentHymn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntermediateHymn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingHymn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingPrayer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacrament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeakerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SacramentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Speaker_Sacrament_SacramentID",
                        column: x => x.SacramentID,
                        principalTable: "Sacrament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_SacramentID",
                table: "Speaker",
                column: "SacramentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Sacrament");
        }
    }
}
