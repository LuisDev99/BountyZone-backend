using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyZone.Infrastructure.Migrations
{
    public partial class RemovePasswordAndUserNamePropertyInPlayerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Players",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Players",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Players",
                type: "text",
                nullable: true);
        }
    }
}
