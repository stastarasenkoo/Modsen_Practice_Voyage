using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voyage.DataAccess.Migrations
{
    public partial class TurnTransportTypeToTransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_TransportTypes_TransportTypeId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "TransportTypes");

            migrationBuilder.DropColumn(
                name: "TransportNumber",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TransportTypeId",
                table: "Trips",
                newName: "TransportId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_TransportTypeId",
                table: "Trips",
                newName: "IX_Trips_TransportId");

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transports_Number",
                table: "Transports",
                column: "Number",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Transports_TransportId",
                table: "Trips",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Transports_TransportId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.RenameColumn(
                name: "TransportId",
                table: "Trips",
                newName: "TransportTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_TransportId",
                table: "Trips",
                newName: "IX_Trips_TransportTypeId");

            migrationBuilder.AddColumn<string>(
                name: "TransportNumber",
                table: "Trips",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TransportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostRate = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_TransportTypes_TransportTypeId",
                table: "Trips",
                column: "TransportTypeId",
                principalTable: "TransportTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
