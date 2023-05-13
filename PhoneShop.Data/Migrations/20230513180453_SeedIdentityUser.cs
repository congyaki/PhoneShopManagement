using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "O_Date",
                table: "tbOrder",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 14, 1, 4, 52, 971, DateTimeKind.Local).AddTicks(1966),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 14, 0, 51, 32, 789, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.InsertData(
                table: "tbAppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"), "e050ce49-3a56-4bc7-800d-3684a9cb8240", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "tbAppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"), 0, "61d621cb-cc88-48bd-8a58-2bb98ce36b01", new DateTime(2003, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "duccong29092003@gmail.com", true, "Cong", "Do", false, null, "duccong29092003@gmail.com", "admin", "AQAAAAEAACcQAAAAELJ/X7DMdDSNAT5O8VHivN0R6ZQA8XfZuVdnnE8k9wBzkvKnKvxV8jQgzBgAVzncAA==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "tbAppUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"), new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"));

            migrationBuilder.DeleteData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"));

            migrationBuilder.DeleteData(
                table: "tbAppUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"), new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783") });

            migrationBuilder.AlterColumn<DateTime>(
                name: "O_Date",
                table: "tbOrder",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 14, 0, 51, 32, 789, DateTimeKind.Local).AddTicks(9851),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 14, 1, 4, 52, 971, DateTimeKind.Local).AddTicks(1966));
        }
    }
}
