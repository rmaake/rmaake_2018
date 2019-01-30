using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectContents",
                columns: table => new
                {
                    ProjectContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImagePath = table.Column<string>(nullable: true),
                    VoiceNotePath = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TimelineId = table.Column<int>(nullable: false),
                    ClientContactInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContents", x => x.ProjectContentId);
                    table.ForeignKey(
                        name: "FK_ProjectContents_ClientContactInfos_ClientContactInfoId",
                        column: x => x.ClientContactInfoId,
                        principalTable: "ClientContactInfos",
                        principalColumn: "ClientContactInfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectContents_Timelines_TimelineId",
                        column: x => x.TimelineId,
                        principalTable: "Timelines",
                        principalColumn: "TimelineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContents_ClientContactInfoId",
                table: "ProjectContents",
                column: "ClientContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContents_TimelineId",
                table: "ProjectContents",
                column: "TimelineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectContents");
        }
    }
}
