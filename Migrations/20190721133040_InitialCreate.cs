using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalCouponApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DiscountPercent = table.Column<float>(nullable: false),
                    RevenueSharePercent = table.Column<float>(nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupon_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ledger",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CouponId = table.Column<Guid>(nullable: false),
                    OriginalPrice = table.Column<double>(nullable: false),
                    DiscountAmount = table.Column<double>(nullable: false),
                    SalesAmount = table.Column<double>(nullable: false),
                    RevenueShareAmount = table.Column<double>(nullable: false),
                    SettlementAmount = table.Column<double>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ledger_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedDateTime", "Email", "Name" },
                values: new object[] { new Guid("12f08dc9-e15d-4583-ba9d-6382f023740c"), new DateTime(2019, 7, 21, 19, 0, 39, 919, DateTimeKind.Local).AddTicks(3238), "jeffrey.ritcher@nowhere.com", "Jeffrey Ritcher" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedDateTime", "Email", "Name" },
                values: new object[] { new Guid("80202dc7-2c4d-457b-a0a0-3e5135268155"), new DateTime(2019, 7, 21, 19, 0, 39, 920, DateTimeKind.Local).AddTicks(8609), "sheldon.couper@nowhere.com", "Sheldon Couper" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedDateTime", "Email", "Name" },
                values: new object[] { new Guid("13b8c87c-efd7-4e50-9675-fdd89f6f01b0"), new DateTime(2019, 7, 21, 19, 0, 39, 920, DateTimeKind.Local).AddTicks(8616), "mike.hill@nowhere.com", "Mike Hill" });

            migrationBuilder.CreateIndex(
                name: "IX_Coupon_CustomerId",
                table: "Coupon",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledger_CouponId",
                table: "Ledger",
                column: "CouponId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ledger");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
