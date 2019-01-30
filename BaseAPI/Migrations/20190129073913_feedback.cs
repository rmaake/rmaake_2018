using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAPI.Migrations
{
    public partial class feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientFeedbacks",
                columns: table => new
                {
                    ClientFeedbackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    VoiceNotePath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimelineId = table.Column<int>(nullable: true),
                    ClientContactInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFeedbacks", x => x.ClientFeedbackId);
                    table.ForeignKey(
                        name: "FK_ClientFeedbacks_ClientContactInfos_ClientContactInfoId",
                        column: x => x.ClientContactInfoId,
                        principalTable: "ClientContactInfos",
                        principalColumn: "ClientContactInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackComments",
                columns: table => new
                {
                    FeedbackCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ClientFeedbackId = table.Column<int>(nullable: false),
                    ClientContactInfoId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackComments", x => x.FeedbackCommentId);
                    table.ForeignKey(
                        name: "FK_FeedbackComments_ClientContactInfos_ClientContactInfoId",
                        column: x => x.ClientContactInfoId,
                        principalTable: "ClientContactInfos",
                        principalColumn: "ClientContactInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedbackComments_ClientFeedbacks_ClientFeedbackId",
                        column: x => x.ClientFeedbackId,
                        principalTable: "ClientFeedbacks",
                        principalColumn: "ClientFeedbackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackComments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFeedbacks_ClientContactInfoId",
                table: "ClientFeedbacks",
                column: "ClientContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackComments_ClientContactInfoId",
                table: "FeedbackComments",
                column: "ClientContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackComments_ClientFeedbackId",
                table: "FeedbackComments",
                column: "ClientFeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackComments_EmployeeId",
                table: "FeedbackComments",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackComments");

            migrationBuilder.DropTable(
                name: "ClientFeedbacks");
        }
    }
}
