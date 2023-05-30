using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class Update_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "e7f5020c-830a-4a33-90cd-1ad1776caa41");

            migrationBuilder.InsertData(
                table: "tbAppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("f621a3f0-4989-4646-9e9c-9a34cc279a70"), "f5b4eaad-4b0b-44dc-9841-4ac7eb13266a", "Manager role", "manager", "manager" });

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f5dc778-f41c-4939-948b-94a7f7e2a1b1", "AQAAAAEAACcQAAAAEEkXz1Ms3bhWvjGxka6/xd2ToyG2qavw5aTGMVZQ4ot6sqX4vyVuzxDU2l8lGXpyiw==" });

            migrationBuilder.InsertData(
                table: "tbAppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("57adb60c-dbe4-4903-b281-030a9331279d"), 0, "2977a53d-a100-4461-9bcf-65b018c23613", new DateTime(2003, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager1@gmail.com", true, "Long", "Do", false, null, "manager1@gmail.com", "manager", "AQAAAAEAACcQAAAAEM9Zgu0LWZe+2BrepqzsVCoYoyK1zOfew/t0SGtdKmU84k/IJPsvAH7MbAFaA3iMPQ==", null, false, "", false, "manager" });

            migrationBuilder.InsertData(
                table: "tbAppUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f621a3f0-4989-4646-9e9c-9a34cc279a70"), new Guid("57adb60c-dbe4-4903-b281-030a9331279d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("f621a3f0-4989-4646-9e9c-9a34cc279a70"));

            migrationBuilder.DeleteData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("57adb60c-dbe4-4903-b281-030a9331279d"));

            migrationBuilder.DeleteData(
                table: "tbAppUserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f621a3f0-4989-4646-9e9c-9a34cc279a70"), new Guid("57adb60c-dbe4-4903-b281-030a9331279d") });

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "3251b433-7991-448a-8e17-85356243fbb9");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5807af50-19da-4e01-9cac-903e65987588", "AQAAAAEAACcQAAAAEH+XjPC9xDRccASC292R1Ce1uKhSNnrdPGSxMGcnGfh1xxAUpHq2NV/V2+Wu8EW+hw==" });
        }
    }
}
