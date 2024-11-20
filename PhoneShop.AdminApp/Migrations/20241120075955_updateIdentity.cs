using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.AdminApp.Migrations
{
    public partial class updateIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5768A50E-31B6-4933-B3B3-B0336F5656E6",
                column: "ConcurrencyStamp",
                value: "9a7580b3-e78a-4765-adda-71852fb71e62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F621A3F0-4989-4646-9E9C-9A34CC279A70",
                column: "ConcurrencyStamp",
                value: "36119ae4-0e06-4485-9b07-3a1e8af64151");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "F621A3F0-4989-4646-9E9C-9A34CC279A73", "e8327882-a01d-48b3-93ae-a4d11f73f5ad", "employee", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57ADB60C-DBE4-4903-B281-030A9331279D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccb89dcc-1860-4c7d-b4e6-619bdca7366e", "AQAAAAEAACcQAAAAENLn6G2Idjg0s9XTNYvPwccFHQ6cHlyRj0oBjfjmNs+KHyWk6dMPceYklqoMQdcehA==", "ffaf01fa-d874-431b-9dbe-38409f7138ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7642BE16-2C21-40F0-81BB-CE85B30B0783",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c0dc39a-3866-4ce8-9a4d-b451495adb82", "AQAAAAEAACcQAAAAENPlwUswjc5ltnufKkRWcTXwmzTHQGcRR2e+cnm4ngfwyJI0NAnnxDDMoSqsLIul/A==", "b7452b82-0508-4008-8c5a-c018058c3ed1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7642BE16-2C21-40F0-81BB-CE85B30B0784", 0, "2a5132d2-811b-44a0-98cb-4b67c02f1721", "employee01@gmail.com", true, "Phong", "Dan", false, null, "EMPLOYEE01@GMAIL.COM", "EMPLOYEE01", "AQAAAAEAACcQAAAAEJkLs5nX5SA4xql3ByIjjDM9KhLLMx9z29tOjGjb0oRgP1RYjFS2CmdpXTJBIyqJbA==", null, false, "092c1fb4-a2b0-4f08-afdf-cc6d7dac19bc", false, "employee01" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "F621A3F0-4989-4646-9E9C-9A34CC279A73", "7642BE16-2C21-40F0-81BB-CE85B30B0784" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "F621A3F0-4989-4646-9E9C-9A34CC279A73", "7642BE16-2C21-40F0-81BB-CE85B30B0784" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F621A3F0-4989-4646-9E9C-9A34CC279A73");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7642BE16-2C21-40F0-81BB-CE85B30B0784");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5768A50E-31B6-4933-B3B3-B0336F5656E6",
                column: "ConcurrencyStamp",
                value: "bf75802c-f256-4836-bc15-840237621fc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F621A3F0-4989-4646-9E9C-9A34CC279A70",
                column: "ConcurrencyStamp",
                value: "975c574d-be71-49a8-af63-7bde909f4726");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57ADB60C-DBE4-4903-B281-030A9331279D",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3e8461a-a6fe-4c79-8795-4b5336f4f8ac", "AQAAAAEAACcQAAAAEHgCgvK6M66FDSC2yzSlVsZntDk+r1fDSQQ8j6Y1t/ky0oN+IeMtJ2kz9CTbTnr3Bg==", "d9c57214-4636-4e28-8cca-10b017189869" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7642BE16-2C21-40F0-81BB-CE85B30B0783",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c78c3b99-7878-4cb4-a12e-665396bd81b9", "AQAAAAEAACcQAAAAEBkRZm85Z2bD7kuaFdyKDjBszDGPzbPZdWSo2nKFpeJ1sHzYLFhmas3Dj54g30eyVQ==", "781bedf9-36c0-42bc-9d17-76c9b1e898b7" });
        }
    }
}
