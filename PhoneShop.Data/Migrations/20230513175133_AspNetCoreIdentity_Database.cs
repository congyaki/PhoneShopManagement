using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class AspNetCoreIdentity_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "O_Date",
                table: "tbOrder",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 14, 0, 51, 32, 789, DateTimeKind.Local).AddTicks(9851),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 13, 14, 51, 56, 498, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.CreateTable(
                name: "tbAppRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAppUserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tbAppUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_tbOrder_UserId",
                table: "tbOrder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbOrder_tbAppUser_UserId",
                table: "tbOrder",
                column: "UserId",
                principalTable: "tbAppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbOrder_tbAppUser_UserId",
                table: "tbOrder");

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

            migrationBuilder.DropIndex(
                name: "IX_tbOrder_UserId",
                table: "tbOrder");

            migrationBuilder.AlterColumn<DateTime>(
                name: "O_Date",
                table: "tbOrder",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 14, 51, 56, 498, DateTimeKind.Local).AddTicks(1227),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 14, 0, 51, 32, 789, DateTimeKind.Local).AddTicks(9851));
        }
    }
}
