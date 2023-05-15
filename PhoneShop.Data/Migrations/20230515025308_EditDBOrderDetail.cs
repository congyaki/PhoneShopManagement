using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class EditDBOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_tbProduct_PId",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "PId",
                table: "ProductImages",
                newName: "P_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_PId",
                table: "ProductImages",
                newName: "IX_ProductImages_P_Id");

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "ad424112-1d62-46cb-9cc2-5bbba9504284");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "552901d0-264b-4cb1-bdcf-a4356ba7a353", "AQAAAAEAACcQAAAAEPFZ9HVSSVjG0rzv10OP1SLa3rRBki50+8G7y6DqyUq2MQCiEOkK/+oAYAFd2aajBA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_tbProduct_P_Id",
                table: "ProductImages",
                column: "P_Id",
                principalTable: "tbProduct",
                principalColumn: "P_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_tbProduct_P_Id",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "P_Id",
                table: "ProductImages",
                newName: "PId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_P_Id",
                table: "ProductImages",
                newName: "IX_ProductImages_PId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_tbProduct_PId",
                table: "ProductImages",
                column: "PId",
                principalTable: "tbProduct",
                principalColumn: "P_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
