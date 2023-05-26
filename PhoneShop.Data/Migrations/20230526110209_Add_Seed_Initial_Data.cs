using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class Add_Seed_Initial_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "P_Avatar",
                table: "tbProduct",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "3251b433-7991-448a-8e17-85356243fbb9");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5807af50-19da-4e01-9cac-903e65987588", "AQAAAAEAACcQAAAAEH+XjPC9xDRccASC292R1Ce1uKhSNnrdPGSxMGcnGfh1xxAUpHq2NV/V2+Wu8EW+hw==" });

            migrationBuilder.InsertData(
                table: "tbCategory",
                columns: new[] { "C_Id", "C_Name", "C_ParentId", "C_SortOrder" },
                values: new object[,]
                {
                    { 6, "OnePlus 9 series", 1, 1 },
                    { 7, "Xiaomi Mi series", 1, 2 },
                    { 8, "OPPO Reno series", 1, 3 },
                    { 9, "Huawei P series", 1, 4 },
                    { 10, "LG G series", 1, 5 },
                    { 11, "Samsung Galaxy Note series", 4, 1 },
                    { 12, "Samsung Galaxy Fold series", 4, 2 },
                    { 13, "Samsung Galaxy Z series", 4, 3 },
                    { 14, "Xiaomi Redmi series", 2, 1 },
                    { 15, "Realme series", 2, 2 },
                    { 16, "Nokia X series", 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "tbCustomer",
                columns: new[] { "Cus_ID", "Cus_Address", "Cus_Email", "Cus_Name", "Cus_Phone" },
                values: new object[,]
                {
                    { 6, "246 Pine St", "mary.brown@example.com", "Mary Brown", "555-2468" },
                    { 7, "135 Oak Ave", "david.lee@example.com", "David Lee", "555-1357" },
                    { 8, "789 Maple St", "sarah.davis@example.com", "Sarah Davis", "555-7891" },
                    { 9, "246 Elm St", "mike.johnson@example.com", "Mike Johnson", "555-2468" },
                    { 10, "135 Park Ave", "lisa.smith@example.com", "Lisa Smith", "555-1357" },
                    { 11, "789 Maple Rd", "daniel.wilson@example.com", "Daniel Wilson", "555-7891" },
                    { 12, "246 Oak Ln", "jessica.lee@example.com", "Jessica Lee", "555-2468" },
                    { 13, "135 Pine St", "mark.brown@example.com", "Mark Brown", "555-1357" },
                    { 14, "789 Park Ave", "emily.davis@example.com", "Emily Davis", "555-7891" },
                    { 15, "246 Elm St", "andrew.johnson@example.com", "Andrew Johnson", "555-2468" },
                    { 16, "135 Maple Rd", "rachel.smith@example.com", "Rachel Smith", "555-1357" }
                });

            migrationBuilder.InsertData(
                table: "tbManufacturer",
                columns: new[] { "M_ID", "M_Address", "M_Email", "M_Name", "M_Phone" },
                values: new object[,]
                {
                    { 6, "Bantian, Longgang District, Shenzhen, China", "support@huawei.com", "Huawei", "+86-755-28780808" },
                    { 7, "1-7-1 Konan, Minato-ku, Tokyo 108-0075, Japan", "support@sony.com", "Sony", "+81-3-6748-2111" },
                    { 8, "128 Yeoui-daero, Yeongdeungpo-gu, Seoul, 07336, South Korea", "support@lg.com", "LG", "+82-2-3777-1114" },
                    { 9, "Karaportti 3, 02610 Espoo, Finland", "support@nokia.com", "Nokia", "+358 (0) 10 44 88 000" },
                    { 10, "222 W Merchandise Mart Plaza #1800, Chicago, IL 60654, USA", "support@motorola.com", "Motorola", "+1 (800) 668-6765" },
                    { 11, "No. 15 Li-De Rd., Beitou District, Taipei 112, Taiwan", "support@asus.com", "Asus", "+886-2-2894-3447" },
                    { 12, "Morrisville, NC 27560, United States", "support@lenovo.com", "Lenovo", "+1-800-426-7378" },
                    { 13, "1600 Amphitheatre Parkway, Mountain View, California 94043, United States of America", "support@google.com", "Google", "+1 650-253-0000" },
                    { 14, "No. 1 Building, Shangdi Xinxi Road, Haidian District, Beijing, China", "support@vivo.com", "Vivo", "+86-755-28780808" }
                });

            migrationBuilder.InsertData(
                table: "tbProduct",
                columns: new[] { "P_ID", "M_Id", "P_Avatar", "P_BatteryCapacity", "P_Camera", "P_Color", "P_Connectivity", "P_Description", "P_Dimension", "P_Name", "P_Operating_System", "P_OriginalPrice", "P_Price", "P_Ram", "P_Resolution", "P_Screen_Size", "P_Stock", "P_Storage", "P_Weights" },
                values: new object[,]
                {
                    { 1, 1, "1.jpg", "5000 mAh", "Quad camera: 108 MP + 10 MP + 10 MP + 12 MP", "Phantom Black", "5G", "Flagship phone from Samsung", "165.1 x 75.6 x 8.9 mm", "Samsung Galaxy S21 Ultra", "Android 11", 1399m, 1199m, "12 GB", "3200 x 1440 pixels", "6.8 inches", 50, "256 GB", "227 g" },
                    { 2, 2, "2.jpg", "3095 mAh", "Triple camera: 12 MP + 12 MP + 12 MP", "Graphite", "5G", "Flagship phone from Apple", "146.7 x 71.5 x 7.7 mm", "iPhone 13 Pro", "iOS 15", 1099m, 999m, "6 GB", "2532 x 1170 pixels", "6.1 inches", 30, "128 GB", "204 g" },
                    { 3, 3, "3.jpg", "4500 mAh", "Triple camera: 50 MP + 8 MP + 2 MP", "Gray Sierra", "5G", "Mid-range phone from OnePlus", "158.9 x 73.2 x 8.3 mm", "OnePlus Nord 2", "Android 11", 429m, 399m, "8 GB", "2400 x 1080 pixels", "6.43 inches", 100, "128 GB", "189 g" },
                    { 4, 4, "4.jpg", "5000 mAh", "Quad camera: 64 MP + 8 MP + 2 MP + 2 MP", "Onyx Gray", "4G", "Mid-range phone from Xiaomi", "164.1 x 76.9 x 8.5 mm", "Xiaomi Redmi Note 11 Pro", "Android 11", 349m, 299m, "6 GB", "2400 x 1080 pixels", "6.67 inches", 150, "64 GB", "193 g" },
                    { 5, 5, "5.jpg", "5000 mAh", "Triple camera: 13 MP + 2 MP + 2 MP", "Crystal Black", "4G", "Budget phone from OPPO", "163.6 x 75.7 x 8.4 mm", "OPPO A54", "Android 10", 249m, 199m, "4 GB", "1600 x 720 pixels", "6.51 inches", 200, "128 GB", "192 g" },
                    { 11, 1, "11.jpg", "4400 mAh", "Triple camera: 12 MP + 12 MP + 12 MP", "Phantom Green", "5G", "Foldable flagship phone from Samsung", "158.2 x 128.1 x 6.4 mm", "Samsung Galaxy Z Fold 3", "Android 11", 1999m, 1799m, "12 GB", "2208 x 1768 pixels", "7.6 inches", 50, "512 GB", "271 g" },
                    { 12, 2, "12.jpg", "1821 mAh", "Single camera: 12 MP", "Product Red", "4G", "Budget phone from Apple", "138.4 x 67.3 x 7.3 mm", "iPhone SE (2022)", "iOS 15", 449m, 399m, "4 GB", "1334 x 750 pixels", "4.7 inches", 100, "64 GB", "148 g" },
                    { 13, 4, "13.jpg", "5000 mAh", "Quad camera: 108 MP + 50 MP + 12 MP + 20 MP", "Cosmic Black", "5G", "Flagship phone from Xiaomi", "164.3 x 74.6 x 8.8 mm", "Xiaomi Mi 12", "Android 12", 1199m, 1099m, "12 GB", "3200 x 1440 pixels", "6.81 inches", 30, "256 GB", "205 g" },
                    { 15, 4, "15.jpg", "5000 mAh", "Quad camera: 108 MP + 10 MP + 10 MP + 12 MP", "Phantom Black", "5G", "Flagship phone from Samsung with the best camera", "165.1 x 75.6 x 8.9 mm", "Samsung Galaxy S21 Ultra", "Android 11", 1799m, 1599m, "16 GB", "3200 x 1440 pixels", "6.8 inches", 70, "512 GB", "229 g" }
                });

            migrationBuilder.InsertData(
                table: "tbProduct",
                columns: new[] { "P_ID", "M_Id", "P_Avatar", "P_BatteryCapacity", "P_Camera", "P_Color", "P_Connectivity", "P_Description", "P_Dimension", "P_Name", "P_Operating_System", "P_OriginalPrice", "P_Price", "P_Ram", "P_Resolution", "P_Screen_Size", "P_Stock", "P_Storage", "P_Weights" },
                values: new object[] { 18, 5, "18.jpg", "4500 mAh", "Quad camera: 50 MP + 48 MP + 8 MP + 2 MP", "Morning Mist", "5G", "Flagship phone from OnePlus", "165.2 x 74.6 x 8.7 mm", "OnePlus 10 Pro", "Android 12", 1399m, 1299m, "12 GB", "3216 x 1440 pixels", "6.7 inches", 60, "512 GB", "199 g" });

            migrationBuilder.InsertData(
                table: "tbProduct",
                columns: new[] { "P_ID", "M_Id", "P_Avatar", "P_BatteryCapacity", "P_Camera", "P_Color", "P_Connectivity", "P_Description", "P_Dimension", "P_Name", "P_Operating_System", "P_OriginalPrice", "P_Price", "P_Ram", "P_Resolution", "P_Screen_Size", "P_Stock", "P_Storage", "P_Weights" },
                values: new object[] { 19, 5, "19.jpg", "4500 mAh", "Quad camera: 50 MP + 50 MP + 13 MP + 5 MP", "Galactic Silver", "5G", "Flagship phone from OPPO", "163.6 x 74 x 8.26 mm", "OPPO Find X5 Pro", "Android 12", 1599m, 1499m, "16 GB", "3216 x 1440 pixels", "6.7 inches", 40, "512 GB", "190 g" });

            migrationBuilder.InsertData(
                table: "tbProduct",
                columns: new[] { "P_ID", "M_Id", "P_Avatar", "P_BatteryCapacity", "P_Camera", "P_Color", "P_Connectivity", "P_Description", "P_Dimension", "P_Name", "P_Operating_System", "P_OriginalPrice", "P_Price", "P_Ram", "P_Resolution", "P_Screen_Size", "P_Stock", "P_Storage", "P_Weights" },
                values: new object[,]
                {
                    { 6, 6, "6.jpg", "4400 mAh", "Quad camera: 50 MP + 64 MP + 13 MP + 40 MP", "Mystic Silver", "5G", "Flagship phone from Huawei", "163.8 x 75.8 x 8.6 mm", "Huawei Mate 50 Pro", "Android 12", 1499m, 1299m, "12 GB", "2772 x 1344 pixels", "6.76 inches", 50, "256 GB", "212 g" },
                    { 7, 7, "7.jpg", "4500 mAh", "Triple camera: 12 MP + 12 MP + 12 MP", "Frosted Black", "5G", "Flagship phone from Sony", "165.0 x 71.0 x 8.2 mm", "Sony Xperia 1 III", "Android 11", 1399m, 1299m, "12 GB", "3840 x 1644 pixels", "6.5 inches", 30, "256 GB", "186 g" },
                    { 8, 8, "8.jpg", "4300 mAh", "Triple camera: 48 MP + 8 MP + 5 MP", "Illusion Sunset", "5G", "Mid-range phone from LG", "167.2 x 74.1 x 7.9 mm", "LG Velvet 5G", "Android 10", 599m, 499m, "6 GB", "2460 x 1080 pixels", "6.8 inches", 100, "128 GB", "180 g" },
                    { 9, 9, "9.jpg", "4470 mAh", "Quad camera: 64 MP + 5 MP + 2 MP + 2 MP", "Midnight Sun", "5G", "Mid-range phone from Nokia", "168.9 x 79.7 x 9.1 mm", "Nokia X20", "Android 11", 499m, 449m, "8 GB", "2400 x 1080 pixels", "6.67 inches", 150, "128 GB", "220 g" },
                    { 10, 10, "10.jpg", "5000 mAh", "Triple camera: 48 MP + 2 MP + 2 MP", "Flash Gray", "4G", "Budget phone from Motorola", "165.3 x 75.9 x 9.5 mm", "Motorola Moto G Power (2022)", "Android 11", 249m, 199m, "4 GB", "1600 x 720 pixels", "6.6 inches", 200, "64 GB", "206 g" },
                    { 14, 11, "14.jpg", "5000 mAh", "Triple camera: 50 MP + 48 MP + 12 MP", "Stormy Black", "5G", "Flagship phone from Google", "163.9 x 75.8 x 8.9 mm", "Google Pixel 6 Pro", "Android 12", 1199m, 1099m, "12 GB", "3120 x 1440 pixels", "6.7 inches", 50, "256 GB", "207 g" },
                    { 16, 13, "16.jpg", "5000 mAh", "Triple camera: 64 MP + 8 MP + 2 MP", "Black", "5G", "Mid-range phone from Realme", "158.5 x 73.3 x 8.4 mm", "Realme GT Neo 2", "Android 11", 449m, 399m, "8 GB", "2400 x 1080 pixels", "6.62 inches", 100, "128 GB", "186 g" },
                    { 17, 14, "17.jpg", "4600 mAh", "Triple camera: 64 MP + 64 MP + 64 MP", "Black", "5G", "Flagship phone from ZTE", "161.5 x 73 x 8 mm", "ZTE Axon 30 Ultra", "Android 11", 799m, 749m, "12 GB", "2400 x 1080 pixels", "6.67 inches", 80, "256 GB", "188 g" },
                    { 20, 12, "20.jpg", "4500 mAh", "Quad camera: 50 MP + 48MP + 12 MP + 8 MP", "Orange", "5G", "Flagship phone from Vivo", "164.8 x 75 x 9 mm", "Vivo X70 Pro+", "Android 11", 1399m, 1299m, "12 GB", "3200 x 1440 pixels", "6.78 inches", 30, "512 GB", "209 g" },
                    { 21, 13, "21.jpg", "4000 mAh", "Dual camera: 12 MP + 12 MP", "Black", "4G", "Smartphone with a physical keyboard from BlackBerry", "151.4 x 71.8 x 8.5 mm", "BlackBerry KEY3", "Android 11", 799m, 699m, "6 GB", "1620 x 1080 pixels", "4.5 inches", 20, "128 GB", "190 g" },
                    { 22, 6, "22.jpg", "4600 mAh", "Quad camera: 50 MP + 64 MP + 13 MP + 3D ToF", "Golden Hour", "5G", "Flagship phone from Honor", "162.8 x 74.9 x 9.5 mm", "Honor Magic 3", "Android 11", 1099m, 999m, "8 GB", "2772 x 1344 pixels", "6.76 inches", 50, "256 GB", "203 g" },
                    { 23, 14, "23.jpg", "5000 mAh", "Triple camera: 108 MP + 24 MP + 12 MP", "Aurora Black", "5G", "Flagship phone from LG", "166.4 x 76.1 x 8.8 mm", "LG V70 ThinQ", "Android 12", 1299m, 1199m, "8 GB", "3200 x 1440 pixels", "6.8 inches", 35, "256 GB", "189 g" },
                    { 24, 7, "24.jpg", "4900 mAh", "Triple camera: 108 MP + 8 MP + 5 MP", "Cosmic Black", "5G", "Mid-range phone from Xiaomi", "164.3 x 74.6 x 8.8 mm", "Xiaomi Mi Note 11", "Android 11", 649m, 599m, "6 GB", "2400 x 1080 pixels", "6.67 inches", 90, "128 GB", "196 g" },
                    { 25, 8, "25.jpg", "5000 mAh", "Triple camera: 108MP + 16 MP + 8 MP", "Midnight Blue", "5G", "Mid-range phone from Motorola", "163.1 x 76.3 x 8.9 mm", "Motorola Edge 30", "Android 11", 549m, 499m, "6 GB", "2400 x 1080 pixels", "6.7 inches", 120, "128 GB", "185 g" }
                });

            migrationBuilder.InsertData(
                table: "tbProductInCategory",
                columns: new[] { "CId", "PId" },
                values: new object[,]
                {
                    { 5, 11 },
                    { 5, 12 },
                    { 6, 13 },
                    { 7, 15 },
                    { 8, 18 },
                    { 8, 19 }
                });

            migrationBuilder.InsertData(
                table: "tbProductInCategory",
                columns: new[] { "CId", "PId" },
                values: new object[,]
                {
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 5, 10 },
                    { 6, 14 },
                    { 7, 16 },
                    { 7, 17 },
                    { 8, 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tbCustomer",
                keyColumn: "Cus_ID",
                keyValue: 16);

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
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 7, 15 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 7, 17 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 8, 18 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 8, 19 });

            migrationBuilder.DeleteData(
                table: "tbProductInCategory",
                keyColumns: new[] { "CId", "PId" },
                keyValues: new object[] { 8, 20 });

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tbCategory",
                keyColumn: "C_Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tbProduct",
                keyColumn: "P_ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tbManufacturer",
                keyColumn: "M_ID",
                keyValue: 14);

            migrationBuilder.AlterColumn<string>(
                name: "P_Avatar",
                table: "tbProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
