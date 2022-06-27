using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Voyage.DataAccess.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "74851e57-2c2b-433e-b604-bac85115cc03", "Administrator", "ADMINISTRATOR" },
                    { 2, "94a9a964-3993-4cb3-ad16-40ac8381e66b", "Driver", "DRIVER" },
                    { 3, "0133335e-b9be-42cb-b350-2a3e879ad13a", "Passenger", "PASSENGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecondName", "SecurityStamp", "ThirdName", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "3f73ff48-b5f5-48de-b780-30a0a863afdb", null, false, "qweqweqwe", false, null, null, "HEADADMIN", "AQAAAAEAACcQAAAAEDls13vOEBjPC656KQfvtFQCoSjsBTTmxck5CSgVizWc1RBKySJHkRyRjdbd4SpazA==", null, false, "admin", "193b9a4e-2ce2-4415-a971-7ae07ce24b32", null, false, "HeadAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
