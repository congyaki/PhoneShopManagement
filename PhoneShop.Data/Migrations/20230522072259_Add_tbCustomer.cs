using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class Add_tbCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbOrder_tbAppUser_UserId",
                table: "tbOrder");

            migrationBuilder.DropIndex(
                name: "IX_tbOrder_UserId",
                table: "tbOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "tbOrder",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CusId",
                table: "tbOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbCustomer",
                columns: table => new
                {
                    Cus_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cus_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cus_Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cus_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cus_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCustomer", x => x.Cus_ID);
                });

            migrationBuilder.UpdateData(
                table: "tbAppRole",
                keyColumn: "Id",
                keyValue: new Guid("5768a50e-31b6-4933-b3b3-b0336f5656e6"),
                column: "ConcurrencyStamp",
                value: "0b04c23f-7451-49d9-bf18-1670e8ec0ef1");

            migrationBuilder.UpdateData(
                table: "tbAppUser",
                keyColumn: "Id",
                keyValue: new Guid("7642be16-2c21-40f0-81bb-ce85b30b0783"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3f5bf929-bfc0-4045-bc02-417942911d26", "AQAAAAEAACcQAAAAEOMATWYqLPrMp/BnklQzrWMDgB/vMssR4nDN+tbKFL2RsAqVBB94OpMZQG67SGWVbw==" });

            migrationBuilder.InsertData(
                table: "tbCustomer",
                columns: new[] { "Cus_ID", "Cus_Address", "Cus_Email", "Cus_Name", "Cus_Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", "john.doe@example.com", "John Doe", "555-1234" },
                    { 2, "456 Park Ave", "jane.smith@example.com", "Jane Smith", "555-5678" },
                    { 3, "789 Elm St", "bob.johnson@example.com", "Bob Johnson", "555-9012" },
                    { 4, "321 Oak Ln", "ann.lee@example.com", "Ann Lee", "555-3456" },
                    { 5, "654 Maple Rd", "tom.wilson@example.com", "Tom Wilson", "555-7890" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbOrder_AppUserId",
                table: "tbOrder",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbOrder_CusId",
                table: "tbOrder",
                column: "CusId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbOrder_tbAppUser_AppUserId",
                table: "tbOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_tbOrder_tbCustomer_CusId",
                table: "tbOrder");

            migrationBuilder.DropTable(
                name: "tbCustomer");

            migrationBuilder.DropIndex(
                name: "IX_tbOrder_AppUserId",
                table: "tbOrder");

            migrationBuilder.DropIndex(
                name: "IX_tbOrder_CusId",
                table: "tbOrder");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "tbOrder");

            migrationBuilder.DropColumn(
                name: "CusId",
                table: "tbOrder");

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

            migrationBuilder.CreateIndex(
                name: "IX_tbOrder_UserId",
                table: "tbOrder",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbOrder_tbAppUser_UserId",
                table: "tbOrder",
                column: "UserId",
                principalTable: "tbAppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
