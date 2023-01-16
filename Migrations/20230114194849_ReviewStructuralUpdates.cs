using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitShop.Migrations
{
    public partial class ReviewStructuralUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDescription",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "MechanicName",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "MechanicId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookingId",
                table: "Review",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MechanicId",
                table: "Review",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Booking_BookingId",
                table: "Review",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Mechanic_MechanicId",
                table: "Review",
                column: "MechanicId",
                principalTable: "Mechanic",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Booking_BookingId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Mechanic_MechanicId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_BookingId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MechanicId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "MechanicId",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingDescription",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MechanicName",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
