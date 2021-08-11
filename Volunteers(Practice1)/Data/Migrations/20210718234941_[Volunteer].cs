using Microsoft.EntityFrameworkCore.Migrations;

namespace Volunteers_Practice1_.Data.Migrations
{
    public partial class Volunteer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "activeStatus",
                table: "Volunteer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activeStatus",
                table: "Volunteer");
        }
    }
}
