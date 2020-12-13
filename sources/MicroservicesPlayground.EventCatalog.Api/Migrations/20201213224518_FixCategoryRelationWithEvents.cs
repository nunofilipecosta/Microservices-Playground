using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroservicesPlayground.EventCatalog.Api.Migrations
{
    public partial class FixCategoryRelationWithEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2021, 10, 13, 22, 45, 17, 920, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2021, 9, 13, 22, 45, 17, 920, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2021, 4, 13, 22, 45, 17, 920, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2021, 8, 13, 22, 45, 17, 920, DateTimeKind.Local).AddTicks(3051));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2021, 4, 13, 22, 45, 17, 920, DateTimeKind.Local).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2021, 6, 13, 22, 45, 17, 917, DateTimeKind.Local).AddTicks(3073));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2021, 10, 13, 18, 56, 11, 915, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2021, 9, 13, 18, 56, 11, 915, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2021, 4, 13, 18, 56, 11, 915, DateTimeKind.Local).AddTicks(1426));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2021, 8, 13, 18, 56, 11, 915, DateTimeKind.Local).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2021, 4, 13, 18, 56, 11, 915, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2021, 6, 13, 18, 56, 11, 909, DateTimeKind.Local).AddTicks(9228));
        }
    }
}
