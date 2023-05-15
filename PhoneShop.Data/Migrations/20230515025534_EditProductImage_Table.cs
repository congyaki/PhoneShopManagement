using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class EditProductImage_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PISortOrder",
                table: "ProductImages");

            migrationBuilder.AlterColumn<int>(
                name: "PI_SortOrder",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "PI_IsDefault",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PI_IsDefault",
                table: "ProductImages");

            migrationBuilder.AlterColumn<bool>(
                name: "PI_SortOrder",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PISortOrder",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
