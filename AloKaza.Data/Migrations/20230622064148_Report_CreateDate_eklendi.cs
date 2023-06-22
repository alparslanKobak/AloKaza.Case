using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AloKaza.Data.Migrations
{
    public partial class Report_CreateDate_eklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Reports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 6, 22, 9, 41, 48, 572, DateTimeKind.Local).AddTicks(7593), new Guid("bb10ef25-ab09-46a2-b1e4-a5c8d1078e4b") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Reports");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 6, 21, 23, 44, 1, 481, DateTimeKind.Local).AddTicks(8974), new Guid("197d4230-1a03-4420-8b7e-0f7891382e44") });
        }
    }
}
