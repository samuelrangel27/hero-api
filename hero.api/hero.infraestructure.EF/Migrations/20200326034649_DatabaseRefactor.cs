using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hero.infraestructure.EF.Migrations
{
    public partial class DatabaseRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuperPower",
                table: "Heroes");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Heroes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Range",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenseiId",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Power",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Power", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroPower",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false),
                    PowerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroPower", x => new { x.HeroId, x.PowerId });
                    table.ForeignKey(
                        name: "FK_HeroPower_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroPower_Power_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Power",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroTeam",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroTeam", x => new { x.HeroId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_HeroTeam_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_SenseiId",
                table: "Heroes",
                column: "SenseiId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroPower_PowerId",
                table: "HeroPower",
                column: "PowerId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroTeam_TeamId",
                table: "HeroTeam",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Heroes_SenseiId",
                table: "Heroes",
                column: "SenseiId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Heroes_SenseiId",
                table: "Heroes");

            migrationBuilder.DropTable(
                name: "HeroPower");

            migrationBuilder.DropTable(
                name: "HeroTeam");

            migrationBuilder.DropTable(
                name: "Power");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_SenseiId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Range",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "SenseiId",
                table: "Heroes");

            migrationBuilder.AddColumn<string>(
                name: "SuperPower",
                table: "Heroes",
                nullable: false,
                defaultValue: "");
        }
    }
}
