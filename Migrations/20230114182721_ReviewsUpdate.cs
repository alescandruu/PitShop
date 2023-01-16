using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitShop.Migrations
{
    public partial class ReviewsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MechanicName",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MechanicName",
                table: "Review");
        }
    }
}
