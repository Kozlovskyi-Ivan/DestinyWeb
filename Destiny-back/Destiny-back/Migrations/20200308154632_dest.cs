using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Destiny_back.Migrations
{
    public partial class dest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Milestones",
                columns: table => new
                {
                    Hash = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    QuestItemHash = table.Column<long>(nullable: false),
                    VendorHash = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestones", x => x.Hash);
                });

            migrationBuilder.CreateTable(
                name: "Activites",
                columns: table => new
                {
                    ActivityHash = table.Column<long>(nullable: false),
                    MilestoneHash = table.Column<long>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activites", x => x.ActivityHash);
                    table.ForeignKey(
                        name: "FK_Activites_Milestones_MilestoneHash",
                        column: x => x.MilestoneHash,
                        principalTable: "Milestones",
                        principalColumn: "Hash",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modifiers",
                columns: table => new
                {
                    ModifierHash = table.Column<long>(nullable: false),
                    ActivityHash = table.Column<long>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifiers", x => x.ModifierHash);
                    table.ForeignKey(
                        name: "FK_Modifiers_Activites_ActivityHash",
                        column: x => x.ActivityHash,
                        principalTable: "Activites",
                        principalColumn: "ActivityHash",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activites_MilestoneHash",
                table: "Activites",
                column: "MilestoneHash");

            migrationBuilder.CreateIndex(
                name: "IX_Modifiers_ActivityHash",
                table: "Modifiers",
                column: "ActivityHash");
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
