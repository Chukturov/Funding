using Microsoft.EntityFrameworkCore.Migrations;

namespace Funding.Migrations
{
    public partial class likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LikeId",
                table: "Post",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikeId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_LikeId",
                table: "Post",
                column: "LikeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LikeId",
                table: "AspNetUsers",
                column: "LikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Like_LikeId",
                table: "AspNetUsers",
                column: "LikeId",
                principalTable: "Like",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Like_LikeId",
                table: "Post",
                column: "LikeId",
                principalTable: "Like",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Like_LikeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Like_LikeId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Post_LikeId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LikeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "AspNetUsers");
        }
    }
}
