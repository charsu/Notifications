using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Notifications.DataAccess.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDateTime",
                table: "Notifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventType",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganisationName",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Notifications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropColumn(
                name: "AppointmentDateTime",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "OrganisationName",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Notifications");
        }
    }
}
