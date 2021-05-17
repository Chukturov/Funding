using Microsoft.EntityFrameworkCore.Migrations;

namespace Funding.Migrations
{
    public partial class cLikeInCImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignImgs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ImgLink = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Alt = table.Column<string>(nullable: true),
                    СampaignId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignImgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignImgs_Campaign_СampaignId",
                        column: x => x.СampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignImgs_СampaignId",
                table: "CampaignImgs",
                column: "СampaignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignImgs");
        }
    }
}
