using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class Data_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "O_Date",
                table: "tbOrder",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 14, 51, 56, 498, DateTimeKind.Local).AddTicks(1227),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 13, 14, 49, 48, 399, DateTimeKind.Local).AddTicks(3628));

            migrationBuilder.InsertData(
                table: "tbCategory",
                columns: new[] { "C_Id", "C_Name", "C_ParentId", "C_SortOrder", "C_Status" },
                values: new object[,]
                {
                    { 1, "Flagship", null, 1, 1 },
                    { 2, "Mid-range", null, 2, 1 },
                    { 3, "Apple iPhone Pro series", 1, 1, 1 },
                    { 4, "Samsung Galaxy S series", 1, 2, 1 },
                    { 5, "Samsung Galaxy A series", 2, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "tbManufacturer",
                columns: new[] { "M_ID", "M_Address", "M_Email", "M_Name", "M_Phone" },
                values: new object[,]
                {
                    { 1, "129 Samsung-ro, Yeongtong-gu, Suwon-si, Gyeonggi-do, Korea", "support@Samsung.com", "SamSung", "+82-31-279-9577" },
                    { 2, "1 Apple Park Way, Cupertino, CA 95014, USA", "info@apple.com", "Apple", "+1 (408) 996-1010" },
                    { 3, "Bantian, Longgang District, Shenzhen, China", "support@oneplus.com", "OnePlus", "+86-755-28780808" },
                    { 4, "Building 3, Wangjing Park, Chaoyang District, Beijing, China", "service.global@xiaomi.com", "Xiaomi", "+86-400-100-5678" },
                    { 5, "1600 Amphitheatre Parkway, Mountain View, California 94043, United States of America", "support@google.com", "OPPO", "+1 650-253-0000" }
                });

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

            migrationBuilder.InsertData(
                table: "tbProductInCategory",
                columns: new[] { "CId", "PId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "O_Date",
                table: "tbOrder",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 13, 14, 49, 48, 399, DateTimeKind.Local).AddTicks(3628),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2023, 5, 13, 14, 51, 56, 498, DateTimeKind.Local).AddTicks(1227));
        }
    }
}
