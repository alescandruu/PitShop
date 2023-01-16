using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitShop.Migrations
{
    public partial class BookingUpdates4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MechanicName",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MechanicName",
                table: "Booking");
        }
    }
}
