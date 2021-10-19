using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMarket.Data.Migrations
{
    public partial class SellOffersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItemInstances_DigitalSellOffers_SellOfferId",
                table: "DigitalItemInstances");

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
                    { new Guid("3ff4ea20-1adb-4141-a296-7b5ec330d144"), "a5544add-900f-4893-886d-ece723901a4e", "Admin", "ADMIN" },
                    { new Guid("33802147-520f-4178-84f1-6ae66243b45e"), "bf55ce82-0601-4c0e-b3ce-ca689527854a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "DigitalRarities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("710bb39a-f836-4999-b509-99676ffc36dd"), "Common" },
                    { new Guid("ff8be82e-97e1-4543-a37f-b4e857deb6b2"), "Rare" },
                    { new Guid("4b15b9b2-c742-4860-acf4-08b5fb9e2a19"), "Super Rare" },
                    { new Guid("8a86db3c-2c1f-4028-8b9d-9e6a4dba12c9"), "Epic" },
                    { new Guid("5cf32c72-960a-4367-852a-8b3388be1e85"), "Legendary" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DigitalSellOffers_InstanceId",
                table: "DigitalSellOffers",
                column: "InstanceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalSellOffers_DigitalItemInstances_InstanceId",
                table: "DigitalSellOffers",
                column: "InstanceId",
                principalTable: "DigitalItemInstances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DigitalSellOffers_DigitalItemInstances_InstanceId",
                table: "DigitalSellOffers");

            migrationBuilder.DropIndex(
                name: "IX_DigitalSellOffers_InstanceId",
                table: "DigitalSellOffers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33802147-520f-4178-84f1-6ae66243b45e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3ff4ea20-1adb-4141-a296-7b5ec330d144"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("4b15b9b2-c742-4860-acf4-08b5fb9e2a19"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("5cf32c72-960a-4367-852a-8b3388be1e85"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("710bb39a-f836-4999-b509-99676ffc36dd"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("8a86db3c-2c1f-4028-8b9d-9e6a4dba12c9"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("ff8be82e-97e1-4543-a37f-b4e857deb6b2"));

            migrationBuilder.AddColumn<Guid>(
                name: "SellOfferId",
                table: "DigitalItemInstances",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
