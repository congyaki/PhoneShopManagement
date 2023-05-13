using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneShop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategory",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    C_SortOrder = table.Column<int>(type: "int", nullable: false),
                    C_ParentId = table.Column<int>(type: "int", nullable: true),
                    C_Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategory", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "tbManufacturer",
                columns: table => new
                {
                    M_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    M_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    M_Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    M_Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    M_Phone = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbManufacturer", x => x.M_ID);
                });

            migrationBuilder.CreateTable(
                name: "tbOrder",
                columns: table => new
                {
                    O_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    O_Date = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(2023, 5, 13, 14, 49, 48, 399, DateTimeKind.Local).AddTicks(3628)),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    O_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbOrder", x => x.O_ID);
                });

            migrationBuilder.CreateTable(
                name: "tbProduct",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    M_Id = table.Column<int>(type: "int", nullable: false),
                    P_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Storage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Ram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Screen_Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Resolution = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Operating_System = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Camera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_BatteryCapacity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Connectivity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Weights = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Dimension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    P_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    P_OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    P_Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProduct", x => x.P_ID);
                    table.ForeignKey(
                        name: "FK_tbProduct_tbManufacturer_M_Id",
                        column: x => x.M_Id,
                        principalTable: "tbManufacturer",
                        principalColumn: "M_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbOrder_Detail",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false),
                    O_ID = table.Column<int>(type: "int", nullable: false),
                    OD_Quantity = table.Column<int>(type: "int", nullable: false),
                    OD_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbOrder_Detail", x => new { x.P_ID, x.O_ID });
                    table.ForeignKey(
                        name: "FK_tbOrder_Detail_tbOrder_O_ID",
                        column: x => x.O_ID,
                        principalTable: "tbOrder",
                        principalColumn: "O_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbOrder_Detail_tbProduct_P_ID",
                        column: x => x.P_ID,
                        principalTable: "tbProduct",
                        principalColumn: "P_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbProductInCategory",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false),
                    CId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProductInCategory", x => new { x.CId, x.PId });
                    table.ForeignKey(
                        name: "FK_tbProductInCategory_tbCategory_CId",
                        column: x => x.CId,
                        principalTable: "tbCategory",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbProductInCategory_tbProduct_PId",
                        column: x => x.PId,
                        principalTable: "tbProduct",
                        principalColumn: "P_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbOrder_Detail_O_ID",
                table: "tbOrder_Detail",
                column: "O_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduct_M_Id",
                table: "tbProduct",
                column: "M_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbProductInCategory_PId",
                table: "tbProductInCategory",
                column: "PId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbOrder_Detail");

            migrationBuilder.DropTable(
                name: "tbProductInCategory");

            migrationBuilder.DropTable(
                name: "tbOrder");

            migrationBuilder.DropTable(
                name: "tbCategory");

            migrationBuilder.DropTable(
                name: "tbProduct");

            migrationBuilder.DropTable(
                name: "tbManufacturer");
        }
    }
}
