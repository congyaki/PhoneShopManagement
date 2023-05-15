using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class AddProdcutImage_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "O_Date",
                table: "tbOrder",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 14, 1, 4, 52, 971, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    PIId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PId = table.Column<int>(type: "int", nullable: false),
                    PIPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PICaption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PIIsDefault = table.Column<bool>(type: "bit", nullable: false),
                    PISortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.PIId);
                    table.ForeignKey(
                        name: "FK_ProductImages_tbProduct_PId",
                        column: x => x.PId,
                        principalTable: "tbProduct",
                        principalColumn: "P_ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_PId",
                table: "ProductImages",
                column: "PId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "O_Date",
                table: "tbOrder",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 14, 1, 4, 52, 971, DateTimeKind.Local).AddTicks(1966),
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "e050ce49-3a56-4bc7-800d-3684a9cb8240");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "61d621cb-cc88-48bd-8a58-2bb98ce36b01", "AQAAAAEAACcQAAAAELJ/X7DMdDSNAT5O8VHivN0R6ZQA8XfZuVdnnE8k9wBzkvKnKvxV8jQgzBgAVzncAA==" });
        }
    }
}
