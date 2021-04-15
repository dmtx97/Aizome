using Microsoft.EntityFrameworkCore.Migrations;

namespace Aizome.Core.Migrations
{
    public partial class removeuniqueids2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimelineId",
                table: "Timelines");

            migrationBuilder.DropColumn(
                name: "JeanId",
                table: "Jeans");

            migrationBuilder.DropColumn(
                name: "BlobId",
                table: "Blobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimelineId",
                table: "Timelines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JeanId",
                table: "Jeans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlobId",
                table: "Blobs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
