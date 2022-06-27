using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voyage.DataAccess.Migrations
{
    public partial class AddRequiredProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "205cf7cf-5698-4f5b-9317-bd474c3abba2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ffd7d59d-1b78-43f6-8c35-416abeee9655");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "777d5b9d-01d1-4619-ab96-d16769700708");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FirstName", "PasswordHash", "SecondName", "SecurityStamp" },
                values: new object[] { "974cea9a-024a-49aa-8f58-48af63569b58", "AdminName", "AQAAAAEAACcQAAAAEC6ZFC7lBds98cJXtAzL7XjwwVs/FRJ6N1e6BKO8eEbK+QPF6zPjWb9zv49BsBFXwQ==", "AdminSecondName", "9c0c3eb1-e426-4f62-9425-bf500e341a92" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "74851e57-2c2b-433e-b604-bac85115cc03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "94a9a964-3993-4cb3-ad16-40ac8381e66b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0133335e-b9be-42cb-b350-2a3e879ad13a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "FirstName", "PasswordHash", "SecondName", "SecurityStamp" },
                values: new object[] { "3f73ff48-b5f5-48de-b780-30a0a863afdb", null, "AQAAAAEAACcQAAAAEDls13vOEBjPC656KQfvtFQCoSjsBTTmxck5CSgVizWc1RBKySJHkRyRjdbd4SpazA==", null, "193b9a4e-2ce2-4415-a971-7ae07ce24b32" });
        }
    }
}
