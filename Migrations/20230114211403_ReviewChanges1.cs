﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PitShop.Migrations
{
    public partial class ReviewChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Mechanic_MechanicId1",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MechanicId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "MechanicId1",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Review",
                newName: "ReviewDescription");

            migrationBuilder.AlterColumn<int>(
                name: "MechanicId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingDescription",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_MechanicId",
                table: "Review",
                column: "MechanicId");

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
                name: "FK_Review_Mechanic_MechanicId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_MechanicId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "BookingDescription",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ReviewDescription",
                table: "Review",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "MechanicId",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MechanicId1",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_MechanicId1",
                table: "Review",
                column: "MechanicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Mechanic_MechanicId1",
                table: "Review",
                column: "MechanicId1",
                principalTable: "Mechanic",
                principalColumn: "Id");
        }
    }
}
