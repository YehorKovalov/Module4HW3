using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITCompany.Migrations
{
    public partial class AddClientTableSeedClientAndProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CooperationStartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "CooperationStartDate", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { -1, new DateTimeOffset(new DateTime(2022, 1, 24, 19, 50, 19, 214, DateTimeKind.Unspecified).AddTicks(2138), new TimeSpan(0, 0, 0, 0, 0)), "Test Email 1", "Test Client 1", "Test PhoneNumber 1" },
                    { -2, new DateTimeOffset(new DateTime(2022, 1, 24, 19, 50, 19, 214, DateTimeKind.Unspecified).AddTicks(2558), new TimeSpan(0, 0, 0, 0, 0)), "Test Email 2", "Test Client 2", "Test PhoneNumber 2" },
                    { -3, new DateTimeOffset(new DateTime(2022, 1, 24, 19, 50, 19, 214, DateTimeKind.Unspecified).AddTicks(2564), new TimeSpan(0, 0, 0, 0, 0)), "Test Email 3", "Test Client 3", "Test PhoneNumber 3" },
                    { -4, new DateTimeOffset(new DateTime(2022, 1, 24, 19, 50, 19, 214, DateTimeKind.Unspecified).AddTicks(2566), new TimeSpan(0, 0, 0, 0, 0)), "Test Email 4", "Test Client 4", "Test PhoneNumber 4" },
                    { -5, new DateTimeOffset(new DateTime(2022, 1, 24, 19, 50, 19, 214, DateTimeKind.Unspecified).AddTicks(2567), new TimeSpan(0, 0, 0, 0, 0)), "Test Email 5", "Test Client 5", "Test PhoneNumber 5" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "ClientID", "Name", "StartedDate" },
                values: new object[,]
                {
                    { -1, 1000000m, -1, "Auto Builder", new DateTime(2022, 1, 24, 19, 50, 19, 208, DateTimeKind.Utc).AddTicks(1047) },
                    { -2, 240000m, -2, "Ambulance caller", new DateTime(2022, 1, 24, 19, 50, 19, 208, DateTimeKind.Utc).AddTicks(1718) },
                    { -3, 1000000m, -3, "Tickects Booking", new DateTime(2022, 1, 24, 19, 50, 19, 208, DateTimeKind.Utc).AddTicks(1722) },
                    { -4, 1000000m, -4, "Test project 1", new DateTime(2022, 1, 24, 19, 50, 19, 208, DateTimeKind.Utc).AddTicks(1724) },
                    { -5, 1000000m, -5, "Test project 2", new DateTime(2022, 1, 24, 19, 50, 19, 208, DateTimeKind.Utc).AddTicks(1726) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientID",
                table: "Project",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientID",
                table: "Project",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientID",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientID",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Project");
        }
    }
}
