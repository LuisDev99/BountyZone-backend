using Microsoft.EntityFrameworkCore.Migrations;

namespace BountyZone.Infrastructure.Migrations
{
    public partial class RenameTableEventLogsToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventLogs_Hunters_HunterID",
                table: "EventLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EventLogs_Leaders_LeaderID",
                table: "EventLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_EventLogs_Leaders_VictimID",
                table: "EventLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventLogs",
                table: "EventLogs");

            migrationBuilder.RenameTable(
                name: "EventLogs",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_EventLogs_VictimID",
                table: "Events",
                newName: "IX_Events_VictimID");

            migrationBuilder.RenameIndex(
                name: "IX_EventLogs_LeaderID",
                table: "Events",
                newName: "IX_Events_LeaderID");

            migrationBuilder.RenameIndex(
                name: "IX_EventLogs_HunterID",
                table: "Events",
                newName: "IX_Events_HunterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Hunters_HunterID",
                table: "Events",
                column: "HunterID",
                principalTable: "Hunters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Leaders_LeaderID",
                table: "Events",
                column: "LeaderID",
                principalTable: "Leaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Leaders_VictimID",
                table: "Events",
                column: "VictimID",
                principalTable: "Leaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Hunters_HunterID",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Leaders_LeaderID",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Leaders_VictimID",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "EventLogs");

            migrationBuilder.RenameIndex(
                name: "IX_Events_VictimID",
                table: "EventLogs",
                newName: "IX_EventLogs_VictimID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_LeaderID",
                table: "EventLogs",
                newName: "IX_EventLogs_LeaderID");

            migrationBuilder.RenameIndex(
                name: "IX_Events_HunterID",
                table: "EventLogs",
                newName: "IX_EventLogs_HunterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventLogs",
                table: "EventLogs",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventLogs_Hunters_HunterID",
                table: "EventLogs",
                column: "HunterID",
                principalTable: "Hunters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventLogs_Leaders_LeaderID",
                table: "EventLogs",
                column: "LeaderID",
                principalTable: "Leaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventLogs_Leaders_VictimID",
                table: "EventLogs",
                column: "VictimID",
                principalTable: "Leaders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
