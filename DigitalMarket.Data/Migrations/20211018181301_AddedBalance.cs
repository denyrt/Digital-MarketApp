using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMarket.Data.Migrations
{
    public partial class AddedBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("827aa62d-3502-4e9e-b707-b33f4ed31bd1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c113a2f9-4a2f-4b4b-984c-c8ec49629445"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("01001a8e-a9d4-42aa-9765-0fa3531b2f3a"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("5386d471-7ca1-4ff8-93c2-24bbcd691c03"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("6f1debbf-15db-4701-b5a5-30386f262775"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("a584f8a9-6865-486f-89af-dc2c264f55d7"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("ce91dad0-c5e3-426f-ac73-54d8f03d7710"));

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("f8f71ad5-c71b-46d6-b822-973d5f63b30e"), "cc8cc1e4-b0d1-486a-9357-301d9f00b65a", "Admin", "ADMIN" },
                    { new Guid("1e423126-5ad2-430d-970a-06b8833471c4"), "09b7734b-93f0-4877-bf2a-f2aa576a540c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "DigitalRarities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("bcc633a3-f93c-4104-b7ad-38dfb69afa54"), "Common" },
                    { new Guid("1e433be6-f599-4833-ab18-0d1c2ecbf672"), "Rare" },
                    { new Guid("5e8d26c0-7b80-47f5-8f4f-4849e28a026e"), "Super Rare" },
                    { new Guid("da4160c9-2e64-4b79-9730-8a4023d7d46b"), "Epic" },
                    { new Guid("249db09b-26e4-4e81-8b65-77e9eedbce6f"), "Legendary" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e423126-5ad2-430d-970a-06b8833471c4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8f71ad5-c71b-46d6-b822-973d5f63b30e"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("1e433be6-f599-4833-ab18-0d1c2ecbf672"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("249db09b-26e4-4e81-8b65-77e9eedbce6f"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("5e8d26c0-7b80-47f5-8f4f-4849e28a026e"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("bcc633a3-f93c-4104-b7ad-38dfb69afa54"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("da4160c9-2e64-4b79-9730-8a4023d7d46b"));

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("827aa62d-3502-4e9e-b707-b33f4ed31bd1"), "150f6c4d-04a0-40f5-a8c3-64f6858b2348", "Admin", "ADMIN" },
                    { new Guid("c113a2f9-4a2f-4b4b-984c-c8ec49629445"), "fc6135cd-54d1-47d2-9e67-57a12fb25f1b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "DigitalRarities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a584f8a9-6865-486f-89af-dc2c264f55d7"), "Common" },
                    { new Guid("6f1debbf-15db-4701-b5a5-30386f262775"), "Rare" },
                    { new Guid("01001a8e-a9d4-42aa-9765-0fa3531b2f3a"), "Super Rare" },
                    { new Guid("5386d471-7ca1-4ff8-93c2-24bbcd691c03"), "Epic" },
                    { new Guid("ce91dad0-c5e3-426f-ac73-54d8f03d7710"), "Legendary" }
                });
        }
    }
}
