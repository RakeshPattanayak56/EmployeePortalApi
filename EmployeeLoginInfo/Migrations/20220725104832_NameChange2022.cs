using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeLoginInfo.Migrations
{
    public partial class NameChange2022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logout",
                table: "EmployeeDetails",
                newName: "LogoutTime");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "EmployeeDetails",
                newName: "LoginTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoutTime",
                table: "EmployeeDetails",
                newName: "Logout");

            migrationBuilder.RenameColumn(
                name: "LoginTime",
                table: "EmployeeDetails",
                newName: "Login");
        }
    }
}
