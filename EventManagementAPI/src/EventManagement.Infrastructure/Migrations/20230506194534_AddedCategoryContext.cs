using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 6, 22, 45, 34, 73, DateTimeKind.Local).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 6, 22, 45, 34, 73, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 6, 22, 45, 34, 73, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 6, 22, 45, 34, 74, DateTimeKind.Local).AddTicks(486), "fmHozsVo2XK8en7u0/+SU5KMtuAG/N3OpZzORpQLHyNIxPiFG0ID0kQPuyDmKrgkScdwqsxDgI2QU3pVu3wZsg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 5, 18, 21, 2, 373, DateTimeKind.Local).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 5, 18, 21, 2, 373, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 5, 18, 21, 2, 373, DateTimeKind.Local).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash" },
                values: new object[] { new DateTime(2023, 5, 5, 18, 21, 2, 373, DateTimeKind.Local).AddTicks(8744), "7621e5c63ac7b718709bfc509a91e4b9368253c8b72849a8d68bfa857ae27c8800c2fc0b586dea78ac4cf1031fe15e653e2af7619800c12f4af14ec771d3f9ea" });
        }
    }
}
