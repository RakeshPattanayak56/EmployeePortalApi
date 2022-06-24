using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeLoginInfo.Migrations
{
    public partial class EmployeeDetail2022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Logout = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InDeskTimeIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InDeskTimeOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetails");
        }
    }
}
