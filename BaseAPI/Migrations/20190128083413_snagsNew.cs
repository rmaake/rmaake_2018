using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAPI.Migrations
{
    public partial class snagsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Defaults_DefaultTypes_DefaultTypeId",
                table: "Defaults");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Defaults");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Defaults");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Defaults",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultTypeId",
                table: "Defaults",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProjectContentId",
                table: "Defaults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Defaults",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Defaults_ProjectContentId",
                table: "Defaults",
                column: "ProjectContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Defaults_DefaultTypes_DefaultTypeId",
                table: "Defaults",
                column: "DefaultTypeId",
                principalTable: "DefaultTypes",
                principalColumn: "DefaultTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Defaults_ProjectContents_ProjectContentId",
                table: "Defaults",
                column: "ProjectContentId",
                principalTable: "ProjectContents",
                principalColumn: "ProjectContentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Defaults_DefaultTypes_DefaultTypeId",
                table: "Defaults");

            migrationBuilder.DropForeignKey(
                name: "FK_Defaults_ProjectContents_ProjectContentId",
                table: "Defaults");

            migrationBuilder.DropIndex(
                name: "IX_Defaults_ProjectContentId",
                table: "Defaults");

            migrationBuilder.DropColumn(
                name: "ProjectContentId",
                table: "Defaults");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Defaults");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Defaults",
                newName: "StartDate");

            migrationBuilder.AlterColumn<int>(
                name: "DefaultTypeId",
                table: "Defaults",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Defaults",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Defaults",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Defaults_DefaultTypes_DefaultTypeId",
                table: "Defaults",
                column: "DefaultTypeId",
                principalTable: "DefaultTypes",
                principalColumn: "DefaultTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
