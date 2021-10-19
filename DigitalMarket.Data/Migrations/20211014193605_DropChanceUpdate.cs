using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMarket.Data.Migrations
{
    public partial class DropChanceUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce320d05-c0c1-4a81-8fb6-8879df926f41"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d95aa340-85d0-499a-8616-df2fac8d2ccb"));

            migrationBuilder.AddColumn<double>(
                name: "DropChance",
                table: "DigitalItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "DropChance",
                table: "DigitalItems");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d95aa340-85d0-499a-8616-df2fac8d2ccb"), "c015e845-51c2-4485-8a2a-81295d960ac2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ce320d05-c0c1-4a81-8fb6-8879df926f41"), "2d087a90-e37d-46cb-bcde-3406e51fcd75", "User", "USER" });
        }
    }
}
