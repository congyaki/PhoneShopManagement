using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class Edit_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbOrder_tbAppUser_AppUserId",
                table: "tbOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_tbOrder_tbCustomer_CusId",
                table: "tbOrder");

            migrationBuilder.DropIndex(
                name: "IX_tbOrder_AppUserId",
                table: "tbOrder");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "tbOrder");

            migrationBuilder.RenameColumn(
                name: "CusId",
                table: "tbOrder",
                newName: "Cus_ID");

            migrationBuilder.RenameIndex(
                name: "IX_tbOrder_CusId",
                table: "tbOrder",
                newName: "IX_tbOrder_Cus_ID");

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "3e703517-1d61-4678-a524-2ca9909adb58");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d7011fc2-717c-4896-add4-a37883b336d7", "AQAAAAEAACcQAAAAEDfu09TGTdpEXZ3xrg1YRqKheRMp3OR5LJ/GX7e9ZoO3Tl2kn4LzwglFThwa5dtkRA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_tbOrder_tbCustomer_Cus_ID",
                table: "tbOrder",
                column: "Cus_ID",
                principalTable: "tbCustomer",
                principalColumn: "Cus_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbOrder_tbCustomer_Cus_ID",
                table: "tbOrder");

            migrationBuilder.RenameColumn(
                name: "Cus_ID",
                table: "tbOrder",
                newName: "CusId");

            migrationBuilder.RenameIndex(
                name: "IX_tbOrder_Cus_ID",
                table: "tbOrder",
                newName: "IX_tbOrder_CusId");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "tbOrder",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "71bde2a2-48ae-4fd9-a4d9-4ef7f73e5347");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1f18f76-e6cb-4937-83e4-b8a84ffd98f6", "AQAAAAEAACcQAAAAEDnhzqck/HZ7wlNqbEtoICLj5CE8O1SdBjr2415yKyNJPSbN1KfljdLAycVxtOTXpA==" });

            migrationBuilder.CreateIndex(
                name: "IX_tbOrder_AppUserId",
                table: "tbOrder",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbOrder_tbAppUser_AppUserId",
                table: "tbOrder",
                column: "AppUserId",
                principalTable: "tbAppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbOrder_tbCustomer_CusId",
                table: "tbOrder",
                column: "CusId",
                principalTable: "tbCustomer",
                principalColumn: "Cus_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
