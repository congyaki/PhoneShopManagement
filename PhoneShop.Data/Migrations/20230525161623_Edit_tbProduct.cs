using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class Edit_tbProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "P_Avatar",
                table: "tbProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "88515ce3-4940-468c-90e7-e2121016a2ce");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6cfef10b-8100-4b9e-9437-ebc7cb91ad79", "AQAAAAEAACcQAAAAEI9YvxEyrb7653RTNEoPzu6cZR2ngxuzC/U/Q+CqviMt37GFVSTN+21w5NyGUDRqSw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_Avatar",
                table: "tbProduct");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    PI_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Id = table.Column<int>(type: "int", nullable: false),
                    PI_Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PI_IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    PI_Path = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PI_SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.PI_Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_tbProduct_P_Id",
                        column: x => x.P_Id,
                        principalTable: "tbProduct",
                        principalColumn: "P_ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "tbProduct",
                columns: new[] { "P_ID", "M_Id", "P_BatteryCapacity", "P_Camera", "P_Color", "P_Connectivity", "P_Description", "P_Dimension", "P_Name", "P_Operating_System", "P_OriginalPrice", "P_Price", "P_Ram", "P_Resolution", "P_Screen_Size", "P_Stock", "P_Storage", "P_Weights" },
                values: new object[,]
                {
                    { 1, 1, "5000 mAh", "Quad camera: 108 MP + 10 MP + 10 MP + 12 MP", "Phantom Black", "5G", "Flagship phone from Samsung", "165.1 x 75.6 x 8.9 mm", "Samsung Galaxy S21 Ultra", "Android 11", 1399m, 1199m, "12 GB", "3200 x 1440 pixels", "6.8 inches", 50, "256 GB", "227 g" },
                    { 2, 2, "3095 mAh", "Triple camera: 12 MP + 12 MP + 12 MP", "Graphite", "5G", "Flagship phone from Apple", "146.7 x 71.5 x 7.7 mm", "iPhone 13 Pro", "iOS 15", 1099m, 999m, "6 GB", "2532 x 1170 pixels", "6.1 inches", 30, "128 GB", "204 g" },
                    { 3, 3, "4500 mAh", "Triple camera: 50 MP + 8 MP + 2 MP", "Gray Sierra", "5G", "Mid-range phone from OnePlus", "158.9 x 73.2 x 8.3 mm", "OnePlus Nord 2", "Android 11", 429m, 399m, "8 GB", "2400 x 1080 pixels", "6.43 inches", 100, "128 GB", "189 g" },
                    { 4, 4, "5000 mAh", "Quad camera: 64 MP + 8 MP + 2 MP + 2 MP", "Onyx Gray", "4G", "Mid-range phone from Xiaomi", "164.1 x 76.9 x 8.5 mm", "Xiaomi Redmi Note 11 Pro", "Android 11", 349m, 299m, "6 GB", "2400 x 1080 pixels", "6.67 inches", 150, "64 GB", "193 g" },
                    { 5, 5, "5000 mAh", "Triple camera: 13 MP + 2 MP + 2 MP", "Crystal Black", "4G", "Budget phone from OPPO", "163.6 x 75.7 x 8.4 mm", "OPPO A54", "Android 10", 249m, 199m, "4 GB", "1600 x 720 pixels", "6.51 inches", 200, "128 GB", "192 g" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_P_Id",
                table: "ProductImages",
                column: "P_Id");
        }
    }
}
