using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAPI.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "ProjectFiles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "ProjectContents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ClientContactInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_EmployeeId",
                table: "ProjectFiles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContents_EmployeeId",
                table: "ProjectContents",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContents_Employees_EmployeeId",
                table: "ProjectContents",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_Employees_EmployeeId",
                table: "ProjectFiles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContents_Employees_EmployeeId",
                table: "ProjectContents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_Employees_EmployeeId",
                table: "ProjectFiles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectFiles_EmployeeId",
                table: "ProjectFiles");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContents_EmployeeId",
                table: "ProjectContents");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ProjectFiles");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ProjectContents");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ClientContactInfos");
        }
    }
}
