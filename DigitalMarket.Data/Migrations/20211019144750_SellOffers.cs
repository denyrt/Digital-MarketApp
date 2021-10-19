using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMarket.Data.Migrations
{
    public partial class SellOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "SellOfferId",
                table: "DigitalItemInstances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DigitalSellOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreateDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalSellOffers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c9fb81b7-b8d5-49ad-bcf5-7035d365d08d"), "19b03a17-db24-4a7c-8be9-6161b13f918f", "Admin", "ADMIN" },
                    { new Guid("48a1672e-ba70-4262-8ac2-d186f78f4bda"), "aa557ac9-fa67-4797-b4b6-95b2d0ce963c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "DigitalRarities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("636df09c-b0f7-4bba-af8c-31ce9e3b7616"), "Common" },
                    { new Guid("87a53ce8-f0ad-41aa-82e7-4ad86e1492af"), "Rare" },
                    { new Guid("db1a51c4-13cc-48b1-aab6-443cf6361577"), "Super Rare" },
                    { new Guid("a3c52f23-8d5d-4916-8ee7-3098dbfe2cee"), "Epic" },
                    { new Guid("2b89ae3e-d4bb-49f9-8b05-22de8d450ddc"), "Legendary" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DigitalItemInstances_SellOfferId",
                table: "DigitalItemInstances",
                column: "SellOfferId",
                unique: true,
                filter: "[SellOfferId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItemInstances_DigitalSellOffers_SellOfferId",
                table: "DigitalItemInstances",
                column: "SellOfferId",
                principalTable: "DigitalSellOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItemInstances_DigitalSellOffers_SellOfferId",
                table: "DigitalItemInstances");

            migrationBuilder.DropTable(
                name: "DigitalSellOffers");

            migrationBuilder.DropIndex(
                name: "IX_DigitalItemInstances_SellOfferId",
                table: "DigitalItemInstances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("48a1672e-ba70-4262-8ac2-d186f78f4bda"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c9fb81b7-b8d5-49ad-bcf5-7035d365d08d"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("2b89ae3e-d4bb-49f9-8b05-22de8d450ddc"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("636df09c-b0f7-4bba-af8c-31ce9e3b7616"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("87a53ce8-f0ad-41aa-82e7-4ad86e1492af"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("a3c52f23-8d5d-4916-8ee7-3098dbfe2cee"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("db1a51c4-13cc-48b1-aab6-443cf6361577"));

            migrationBuilder.DropColumn(
                name: "SellOfferId",
                table: "DigitalItemInstances");

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
    }
}
