using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AloKaza.Data.Migrations
{
    public partial class AppLogs_edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppLog",
                table: "AppLog");

            migrationBuilder.RenameTable(
                name: "AppLog",
                newName: "AppLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppLogs",
                table: "AppLogs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 6, 21, 16, 19, 31, 557, DateTimeKind.Local).AddTicks(8983), new Guid("22cff2a5-87b4-49a1-893f-db1929617bef") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppLogs",
                table: "AppLogs");

            migrationBuilder.RenameTable(
                name: "AppLogs",
                newName: "AppLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppLog",
                table: "AppLog",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 6, 21, 15, 38, 25, 469, DateTimeKind.Local).AddTicks(3831), new Guid("8628ad4c-19a5-4ff1-87d1-a95dfae3c7a3") });
        }
    }
}
