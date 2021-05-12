using Microsoft.EntityFrameworkCore.Migrations;

namespace Funding.Migrations
{
    public partial class likes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Like_LikeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Like_LikeId",
                table: "Post");

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

            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "Like",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Like",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostId",
                table: "Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Post_PostId",
                table: "Like",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_UserId",
                table: "Like",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Post_PostId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_UserId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_PostId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_UserId",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Like");

            migrationBuilder.AddColumn<string>(
                name: "LikeId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikeId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}
