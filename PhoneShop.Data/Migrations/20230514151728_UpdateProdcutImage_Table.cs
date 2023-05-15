using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class UpdateProdcutImage_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PIPath",
                table: "ProductImages",
                newName: "PI_Path");

            migrationBuilder.RenameColumn(
                name: "PIIsDefault",
                table: "ProductImages",
                newName: "PI_SortOrder");

            migrationBuilder.RenameColumn(
                name: "PICaption",
                table: "ProductImages",
                newName: "PI_Caption");

            migrationBuilder.RenameColumn(
                name: "PIId",
                table: "ProductImages",
                newName: "PI_Id");

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "8f9fe24d-972d-45b7-9f39-2946bae9d663");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f4ac792-9a63-4605-b1fc-063da1024051", "AQAAAAEAACcQAAAAEAekddDz9TyrEonEGgpfDQWBV8FeYJ0SEu/ybxxfTtS0La10JmTEQBdNKnprRqPNIQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PI_SortOrder",
                table: "ProductImages",
                newName: "PIIsDefault");

            migrationBuilder.RenameColumn(
                name: "PI_Path",
                table: "ProductImages",
                newName: "PIPath");

            migrationBuilder.RenameColumn(
                name: "PI_Caption",
                table: "ProductImages",
                newName: "PICaption");

            migrationBuilder.RenameColumn(
                name: "PI_Id",
                table: "ProductImages",
                newName: "PIId");

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "e9c87203-0812-4a32-a0a7-4bcf5b3ed756");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a944144c-175b-4977-b02d-ab0b56c09a8a", "AQAAAAEAACcQAAAAENcwyQjo1VaSbNntq2fduslC2hy0jSFXwdjGsPAKqTqbPtxJBeged249HVNIdx1mJw==" });
        }
    }
}
