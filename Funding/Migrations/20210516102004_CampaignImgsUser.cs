using Microsoft.EntityFrameworkCore.Migrations;

namespace Funding.Migrations
{
    public partial class CampaignImgsUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FundingUserId",
                table: "CampaignImgs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CampaignImgs_FundingUserId",
                table: "CampaignImgs",
                column: "FundingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignImgs_AspNetUsers_FundingUserId",
                table: "CampaignImgs",
                column: "FundingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignImgs_AspNetUsers_FundingUserId",
                table: "CampaignImgs");

            migrationBuilder.DropIndex(
                name: "IX_CampaignImgs_FundingUserId",
                table: "CampaignImgs");

            migrationBuilder.DropColumn(
                name: "FundingUserId",
                table: "CampaignImgs");
        }
    }
}
