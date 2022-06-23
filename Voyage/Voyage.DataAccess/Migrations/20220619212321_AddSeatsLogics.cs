using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voyage.DataAccess.Migrations
{
    public partial class AddSeatsLogics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FreeSeats",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookedSeats",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeSeats",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "BookedSeats",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tickets");
        }
    }
}
