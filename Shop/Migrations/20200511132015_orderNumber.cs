using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Migrations
{
    public partial class orderNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderNumber",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "123b9e23-2536-470b-b5d0-3ada5702a4cd", "e0f9b714-12e3-48c3-925d-11d64d2f5e07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderNumber",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73efa01e-30cd-4df0-950c-7510ca256efc", "174b3e7b-755c-42b8-98ba-aa4469ca8721" });
        }
    }
}
