using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMarket.Data.Migrations
{
    public partial class CollectionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "DigitalItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableAtMarket",
                table: "DigitalCollections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "DigitalCollections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "DigitalCollections",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("249085b8-8380-4fa6-832d-927fe5137f05"), "e6044851-ae9f-478a-b192-37c69dda18e0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("cd22ad33-8390-4413-ad42-f0d5debbc668"), "98fe1d08-c83c-42df-9386-5c53bc22f75e", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("249085b8-8380-4fa6-832d-927fe5137f05"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd22ad33-8390-4413-ad42-f0d5debbc668"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "DigitalItems");

            migrationBuilder.DropColumn(
                name: "AvailableAtMarket",
                table: "DigitalCollections");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "DigitalCollections");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DigitalCollections");
        }
    }
}
