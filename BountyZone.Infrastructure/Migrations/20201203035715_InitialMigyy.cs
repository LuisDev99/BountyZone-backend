using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BountyZone.Infrastructure.Migrations
{
    public partial class InitialMigyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NickName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hunters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Guns = table.Column<int>(type: "integer", nullable: false),
                    Bribes = table.Column<int>(type: "integer", nullable: false),
                    PlayerID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hunters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hunters_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Money = table.Column<int>(type: "integer", nullable: false),
                    Reputation = table.Column<int>(type: "integer", nullable: false),
                    SuccessfulAttacks = table.Column<int>(type: "integer", nullable: false),
                    SuccessfulDefends = table.Column<int>(type: "integer", nullable: false),
                    PlayerID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Leaders_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bounties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Bribed = table.Column<bool>(type: "boolean", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    LeaderID = table.Column<int>(type: "integer", nullable: false),
                    VictimID = table.Column<int>(type: "integer", nullable: false),
                    HunterID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bounties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bounties_Hunters_HunterID",
                        column: x => x.HunterID,
                        principalTable: "Hunters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bounties_Leaders_LeaderID",
                        column: x => x.LeaderID,
                        principalTable: "Leaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bounties_Leaders_VictimID",
                        column: x => x.VictimID,
                        principalTable: "Leaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeaderID = table.Column<int>(type: "integer", nullable: false),
                    VictimID = table.Column<int>(type: "integer", nullable: false),
                    HunterID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventLogs_Hunters_HunterID",
                        column: x => x.HunterID,
                        principalTable: "Hunters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventLogs_Leaders_LeaderID",
                        column: x => x.LeaderID,
                        principalTable: "Leaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventLogs_Leaders_VictimID",
                        column: x => x.VictimID,
                        principalTable: "Leaders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bounties_HunterID",
                table: "Bounties",
                column: "HunterID");

            migrationBuilder.CreateIndex(
                name: "IX_Bounties_LeaderID",
                table: "Bounties",
                column: "LeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_Bounties_VictimID",
                table: "Bounties",
                column: "VictimID");

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_HunterID",
                table: "EventLogs",
                column: "HunterID");

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_LeaderID",
                table: "EventLogs",
                column: "LeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_VictimID",
                table: "EventLogs",
                column: "VictimID");

            migrationBuilder.CreateIndex(
                name: "IX_Hunters_PlayerID",
                table: "Hunters",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_PlayerID",
                table: "Leaders",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bounties");

            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "Hunters");

            migrationBuilder.DropTable(
                name: "Leaders");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
