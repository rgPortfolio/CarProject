using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EngineDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    Liters = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    Turbo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Rims = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InteriorDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Upholstery = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SoundSystem = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HasAndroidAutoOrCarPlay = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafetyDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InteriorDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExteriorDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EngineDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SafetyDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_EngineDetails_EngineDetailId",
                        column: x => x.EngineDetailId,
                        principalTable: "EngineDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Details_ExteriorDetails_ExteriorDetailId",
                        column: x => x.ExteriorDetailId,
                        principalTable: "ExteriorDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Details_InteriorDetails_InteriorDetailId",
                        column: x => x.InteriorDetailId,
                        principalTable: "InteriorDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Details_SafetyDetails_SafetyDetailId",
                        column: x => x.SafetyDetailId,
                        principalTable: "SafetyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    DetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Details_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DetailId",
                table: "Cars",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_EngineDetailId",
                table: "Details",
                column: "EngineDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ExteriorDetailId",
                table: "Details",
                column: "ExteriorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_InteriorDetailId",
                table: "Details",
                column: "InteriorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_SafetyDetailId",
                table: "Details",
                column: "SafetyDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "EngineDetails");

            migrationBuilder.DropTable(
                name: "ExteriorDetails");

            migrationBuilder.DropTable(
                name: "InteriorDetails");

            migrationBuilder.DropTable(
                name: "SafetyDetails");
        }
    }
}
