using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BountyZone.Infrastructure.Migrations
{
    public partial class AddPlayerRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerRoleID",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlayerRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRoles", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerRoleID",
                table: "Players",
                column: "PlayerRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerRoles_PlayerRoleID",
                table: "Players",
                column: "PlayerRoleID",
                principalTable: "PlayerRoles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerRoles_PlayerRoleID",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerRoles");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerRoleID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerRoleID",
                table: "Players");
        }
    }
}
