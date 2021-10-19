using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMarket.Data.Migrations
{
    public partial class TinyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItemInstances_AspNetUsers_OwnerId",
                table: "DigitalItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItemInstances_DigitalItems_ItemId",
                table: "DigitalItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItems_DigitalCollections_DigitalCollectionId",
                table: "DigitalItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItems_DigitalRarities_DigitalRarityId",
                table: "DigitalItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e165e102-236d-4d14-817f-1e7a781ce064"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff262ae8-3c50-458d-976c-74f3fb0a3d61"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("4a9eb6be-113f-4cb8-b2cc-5d4e7a123683"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("732d70aa-a8e7-4483-82cc-d970772ea49e"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("8fa8f8ba-ddb2-4361-bd1e-7b709d9ca061"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("ba1e493a-b24e-4da6-8cea-d311dffc64c7"));

            migrationBuilder.DeleteData(
                table: "DigitalRarities",
                keyColumn: "Id",
                keyValue: new Guid("d7807886-1b85-4f2e-81c3-d24efde6216f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateUtc",
                table: "DigitalItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItemInstances_AspNetUsers_OwnerId",
                table: "DigitalItemInstances",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItemInstances_DigitalItems_ItemId",
                table: "DigitalItemInstances",
                column: "ItemId",
                principalTable: "DigitalItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItems_DigitalCollections_DigitalCollectionId",
                table: "DigitalItems",
                column: "DigitalCollectionId",
                principalTable: "DigitalCollections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItems_DigitalRarities_DigitalRarityId",
                table: "DigitalItems",
                column: "DigitalRarityId",
                principalTable: "DigitalRarities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItemInstances_AspNetUsers_OwnerId",
                table: "DigitalItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItemInstances_DigitalItems_ItemId",
                table: "DigitalItemInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItems_DigitalCollections_DigitalCollectionId",
                table: "DigitalItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DigitalItems_DigitalRarities_DigitalRarityId",
                table: "DigitalItems");

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

            migrationBuilder.DropColumn(
                name: "CreateDateUtc",
                table: "DigitalItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("e165e102-236d-4d14-817f-1e7a781ce064"), "25b9ef16-2e56-4270-b814-065fed31852a", "Admin", "ADMIN" },
                    { new Guid("ff262ae8-3c50-458d-976c-74f3fb0a3d61"), "45d66f58-edba-49f5-9959-cd15f33b84d1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "DigitalRarities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4a9eb6be-113f-4cb8-b2cc-5d4e7a123683"), "Common" },
                    { new Guid("732d70aa-a8e7-4483-82cc-d970772ea49e"), "Rare" },
                    { new Guid("d7807886-1b85-4f2e-81c3-d24efde6216f"), "Super Rare" },
                    { new Guid("ba1e493a-b24e-4da6-8cea-d311dffc64c7"), "Epic" },
                    { new Guid("8fa8f8ba-ddb2-4361-bd1e-7b709d9ca061"), "Legendary" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItemInstances_AspNetUsers_OwnerId",
                table: "DigitalItemInstances",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItemInstances_DigitalItems_ItemId",
                table: "DigitalItemInstances",
                column: "ItemId",
                principalTable: "DigitalItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItems_DigitalCollections_DigitalCollectionId",
                table: "DigitalItems",
                column: "DigitalCollectionId",
                principalTable: "DigitalCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DigitalItems_DigitalRarities_DigitalRarityId",
                table: "DigitalItems",
                column: "DigitalRarityId",
                principalTable: "DigitalRarities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
