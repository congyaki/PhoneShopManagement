using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class Remove_User_PhoneShopDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAppRole");

            migrationBuilder.DropTable(
                name: "tbAppRoleClaim");

            migrationBuilder.DropTable(
                name: "tbAppUser");

            migrationBuilder.DropTable(
                name: "tbAppUserClaim");

            migrationBuilder.DropTable(
                name: "tbAppUserLogin");

            migrationBuilder.DropTable(
                name: "tbAppUserRole");

            migrationBuilder.DropTable(
                name: "tbAppUserToken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAppRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAppRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppRoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAppUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppUserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAppUserLogin",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppUserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tbAppUserRole",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppUserRole", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "tbAppUserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppUserToken", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "tbAppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"), "e7f5020c-830a-4a33-90cd-1ad1776caa41", "Administrator role", "admin", "admin" },
                    { new Guid("f621a3f0-4989-4646-9e9c-9a34cc279a70"), "f5b4eaad-4b0b-44dc-9841-4ac7eb13266a", "Manager role", "manager", "manager" }
                });

            migrationBuilder.InsertData(
                table: "tbAppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("57adb60c-dbe4-4903-b281-030a9331279d"), 0, "2977a53d-a100-4461-9bcf-65b018c23613", new DateTime(2003, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager1@gmail.com", true, "Long", "Do", false, null, "manager1@gmail.com", "manager", "AQAAAAEAACcQAAAAEM9Zgu0LWZe+2BrepqzsVCoYoyK1zOfew/t0SGtdKmU84k/IJPsvAH7MbAFaA3iMPQ==", null, false, "", false, "manager" },
                    { new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"), 0, "3f5dc778-f41c-4939-948b-94a7f7e2a1b1", new DateTime(2003, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "duccong29092003@gmail.com", true, "Cong", "Do", false, null, "duccong29092003@gmail.com", "admin", "AQAAAAEAACcQAAAAEEkXz1Ms3bhWvjGxka6/xd2ToyG2qavw5aTGMVZQ4ot6sqX4vyVuzxDU2l8lGXpyiw==", null, false, "", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "tbAppUserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"), new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783") },
                    { new Guid("f621a3f0-4989-4646-9e9c-9a34cc279a70"), new Guid("57adb60c-dbe4-4903-b281-030a9331279d") }
                });
        }
    }
}
