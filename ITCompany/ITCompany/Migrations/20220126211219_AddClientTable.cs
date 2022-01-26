using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITCompany.Migrations
{
    public partial class AddClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Project",
                type: "int",
                nullable: true);

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
                    { -1, new DateTimeOffset(new DateTime(2022, 1, 26, 21, 12, 19, 230, DateTimeKind.Unspecified).AddTicks(3358), new TimeSpan(0, 0, 0, 0, 0)), "Email 1", "Client 1", "PhoneNumber 1" },
                    { -2, new DateTimeOffset(new DateTime(2022, 1, 26, 21, 12, 19, 230, DateTimeKind.Unspecified).AddTicks(3783), new TimeSpan(0, 0, 0, 0, 0)), "Email 2", "Client 2", "PhoneNumber 2" },
                    { -3, new DateTimeOffset(new DateTime(2022, 1, 26, 21, 12, 19, 230, DateTimeKind.Unspecified).AddTicks(3789), new TimeSpan(0, 0, 0, 0, 0)), "Email 3", "Client 3", "PhoneNumber 3" },
                    { -4, new DateTimeOffset(new DateTime(2022, 1, 26, 21, 12, 19, 230, DateTimeKind.Unspecified).AddTicks(3791), new TimeSpan(0, 0, 0, 0, 0)), "Email 4", "Client 4", "PhoneNumber 4" },
                    { -5, new DateTimeOffset(new DateTime(2022, 1, 26, 21, 12, 19, 230, DateTimeKind.Unspecified).AddTicks(3793), new TimeSpan(0, 0, 0, 0, 0)), "Email 5", "Client 5", "PhoneNumber 5" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "Budget", "ClientID", "Name", "StartedDate" },
                values: new object[,]
                {
                    { -1, 1000000m, -1, "Test project 1", new DateTime(2022, 1, 26, 21, 12, 19, 220, DateTimeKind.Utc).AddTicks(1408) },
                    { -2, 1000000m, -2, "Test project 2", new DateTime(2022, 1, 26, 21, 12, 19, 220, DateTimeKind.Utc).AddTicks(2518) },
                    { -3, 1000000m, -3, "Test project 3", new DateTime(2022, 1, 26, 21, 12, 19, 220, DateTimeKind.Utc).AddTicks(2524) },
                    { -4, 1000000m, -4, "Test project 4", new DateTime(2022, 1, 26, 21, 12, 19, 220, DateTimeKind.Utc).AddTicks(2526) },
                    { -5, 1000000m, -5, "Test project 5", new DateTime(2022, 1, 26, 21, 12, 19, 220, DateTimeKind.Utc).AddTicks(2528) }
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
