using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMarket.Data.Migrations
{
    public partial class AddedTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("249085b8-8380-4fa6-832d-927fe5137f05"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd22ad33-8390-4413-ad42-f0d5debbc668"));

            migrationBuilder.CreateTable(
                name: "DigitalTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DigitalTransactions_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DigitalTransactions_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DigitalTransactions_DigitalItemInstances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "DigitalItemInstances",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d95aa340-85d0-499a-8616-df2fac8d2ccb"), "c015e845-51c2-4485-8a2a-81295d960ac2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ce320d05-c0c1-4a81-8fb6-8879df926f41"), "2d087a90-e37d-46cb-bcde-3406e51fcd75", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_DigitalTransactions_FromUserId",
                table: "DigitalTransactions",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalTransactions_InstanceId",
                table: "DigitalTransactions",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalTransactions_ToUserId",
                table: "DigitalTransactions",
                column: "ToUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DigitalTransactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ce320d05-c0c1-4a81-8fb6-8879df926f41"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d95aa340-85d0-499a-8616-df2fac8d2ccb"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("249085b8-8380-4fa6-832d-927fe5137f05"), "e6044851-ae9f-478a-b192-37c69dda18e0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("cd22ad33-8390-4413-ad42-f0d5debbc668"), "98fe1d08-c83c-42df-9386-5c53bc22f75e", "User", "USER" });
        }
    }
}
