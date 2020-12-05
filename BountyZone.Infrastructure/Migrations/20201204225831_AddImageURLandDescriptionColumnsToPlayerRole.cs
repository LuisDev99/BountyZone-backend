using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyZone.Infrastructure.Migrations
{
    public partial class AddImageURLandDescriptionColumnsToPlayerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PlayerRoles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "PlayerRoles",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PlayerRoles");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "PlayerRoles");
        }
    }
}
