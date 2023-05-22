using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class edit_tbCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "C_Status",
                table: "tbCategory");

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "9225fe69-8f63-4f26-b10d-64760ca99d49");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0ee0f33-6cf1-4fd1-a06f-b08589dfeaed", "AQAAAAEAACcQAAAAEBB+R9RtDC2iKOhZNas/yUlIxrI1gIcAMouRqfZRQ+duU415yIedxPZcRXoOiNBJQQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "C_Status",
                table: "tbCategory",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "be9cf751-c304-431c-8fc7-97601f495148");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea26bffa-8a41-4463-b409-a76f484df6d7", "AQAAAAEAACcQAAAAEJzg4/4ShDR2Na+6kH/5fj/EcFiBthJRdYDdB4MnAScMrwVGjMzd98hvb6gBDm0HAw==" });

            migrationBuilder.UpdateData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 1,
                column: "C_Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 2,
                column: "C_Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 3,
                column: "C_Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 4,
                column: "C_Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 5,
                column: "C_Status",
                value: 1);
        }
    }
}
