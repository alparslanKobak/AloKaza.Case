using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AloKaza.Data.Migrations
{
    public partial class Slider_Id_Duzenlendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 6, 21, 23, 41, 0, 123, DateTimeKind.Local).AddTicks(848), new Guid("18409ea1-18ce-49e1-aebe-97af42b026ba") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 6, 21, 16, 19, 31, 557, DateTimeKind.Local).AddTicks(8983), new Guid("22cff2a5-87b4-49a1-893f-db1929617bef") });
        }
    }
}
