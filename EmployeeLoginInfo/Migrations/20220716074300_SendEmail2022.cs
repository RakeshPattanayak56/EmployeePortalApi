using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeLoginInfo.Migrations
{
    public partial class SendEmail2022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InDeskTimeIn",
                table: "EmployeeDetails");

            migrationBuilder.DropColumn(
                name: "InDeskTimeOut",
                table: "EmployeeDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Logout",
                table: "EmployeeDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Logout",
                table: "EmployeeDetails",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "InDeskTimeIn",
                table: "EmployeeDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InDeskTimeOut",
                table: "EmployeeDetails",
                type: "datetime2",
                nullable: true);
        }
    }
}
