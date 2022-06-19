using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voyage.DataAccess.Migrations
{
    public partial class MovePriceRelatedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseCost",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Tickets");

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Trips",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "Routes",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "Routes");

            migrationBuilder.AddColumn<decimal>(
                name: "BaseCost",
                table: "Trips",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Tickets",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
