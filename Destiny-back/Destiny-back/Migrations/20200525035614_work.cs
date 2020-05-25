using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Destiny_back.Migrations
{
    public partial class work : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Milestones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    QuestItemHash = table.Column<long>(nullable: false),
                    VendorHash = table.Column<long>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MilestoneId = table.Column<int>(nullable: true),
                    ActivityHash = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activites_Milestones_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "Milestones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(nullable: true),
                    ModifierHash = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modifiers_Activites_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activites_MilestoneId",
                table: "Activites",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifiers_ActivityId",
                table: "Modifiers",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modifiers");

            migrationBuilder.DropTable(
                name: "Activites");

            migrationBuilder.DropTable(
                name: "Milestones");
        }
    }
}
