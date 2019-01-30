using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAPI.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExternalQuotes_SupplierId",
                table: "ExternalQuotes",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalQuotes_ExternalSuppliers_SupplierId",
                table: "ExternalQuotes",
                column: "SupplierId",
                principalTable: "ExternalSuppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalQuotes_ExternalSuppliers_SupplierId",
                table: "ExternalQuotes");

            migrationBuilder.DropIndex(
                name: "IX_ExternalQuotes_SupplierId",
                table: "ExternalQuotes");
        }
    }
}
