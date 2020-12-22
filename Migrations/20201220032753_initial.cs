using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcomerceProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    price = table.Column<int>(nullable: false),
                    saleprice = table.Column<int>(nullable: false),
                    finalprice = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    update_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(nullable: false),
                    content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    avatar = table.Column<string>(nullable: true),
                    level = table.Column<bool>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    create_at = table.Column<DateTime>(nullable: false),
                    update_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<float>(nullable: false),
                    orderid = table.Column<int>(nullable: false),
                    productid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_orderid",
                        column: x => x.orderid,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "create_at", "finalprice", "image", "name", "price", "saleprice", "status", "update_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(6033), 4600, "image/p1.jpg", "Nokia", 5000, 400, 1, new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(6574) },
                    { 2, new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7136), 4600, "image/p2.jpg", "Samsung Galaxy", 5000, 400, 1, new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7148) },
                    { 3, new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7158), 4600, "image/p3.jpg", "Samsung Note", 5000, 400, 1, new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7159) },
                    { 4, new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7161), 4600, "image/p4.jpg", "Iphone", 5000, 400, 1, new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7162) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "address", "avatar", "create_at", "email", "level", "name", "password", "phone", "status", "update_at" },
                values: new object[,]
                {
                    { 1, "binh thanh", "image/p1.png", new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(99), "toilahuy098@gmail.com", true, "huy", "123456", "0933691822", true, new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(8767) },
                    { 2, "quan 3", "image/p2.png", new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9458), "thaochi098@gmail.com", false, "chi", "123456", "0933691822", true, new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9471) },
                    { 3, "quan 3", "image/p2.png", new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9541), "hoaixp@gmail.com", false, "hoai", "123456", "0933691822", true, new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9543) },
                    { 4, "quan 3", "image/p2.png", new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9545), "lanttm@gmail.com", false, "lan", "123456", "0933691822", true, new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9546) },
                    { 5, "quan 3", "image/p2.png", new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9548), "lanttm@gmail.com", false, "lan", "123456", "0933691822", true, new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9549) }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "address", "email", "name", "phone", "status", "userid" },
                values: new object[,]
                {
                    { 1, "binh thanh", "toilahuy098@gmail.com", "huy", "0933691822", true, 1 },
                    { 2, "binh thanh", "toilahuy098@gmail.com", "huy", "0933691822", true, 1 },
                    { 3, "binh thanh", "toilahuy098@gmail.com", "hoai", "0933691822", true, 2 },
                    { 4, "binh thanh", "toilahuy098@gmail.com", "hoai", "0933691822", true, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "id", "orderid", "price", "productid", "quantity" },
                values: new object[] { 1, 1, 5000f, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Order_userid",
                table: "Order",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_orderid",
                table: "OrderDetail",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_productid",
                table: "OrderDetail",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
