using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAPI.Migrations
{
    public partial class employeeRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeRoleId",
                table: "EmployeeTimeline",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    EmployeeRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.EmployeeRoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeline_EmployeeRoleId",
                table: "EmployeeTimeline",
                column: "EmployeeRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTimeline_EmployeeRoles_EmployeeRoleId",
                table: "EmployeeTimeline",
                column: "EmployeeRoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "EmployeeRoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTimeline_EmployeeRoles_EmployeeRoleId",
                table: "EmployeeTimeline");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTimeline_EmployeeRoleId",
                table: "EmployeeTimeline");

            migrationBuilder.DropColumn(
                name: "EmployeeRoleId",
                table: "EmployeeTimeline");
        }
    }
}
