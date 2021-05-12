using Microsoft.EntityFrameworkCore.Migrations;

namespace Funding.Migrations
{
    public partial class CampaignsDescr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Campaign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Campaign",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Campaign");
        }
    }
}
