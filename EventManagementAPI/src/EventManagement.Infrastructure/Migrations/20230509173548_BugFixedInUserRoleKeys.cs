using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BugFixedInUserRoleKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_UserID",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 9, 20, 35, 48, 715, DateTimeKind.Local).AddTicks(92));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 9, 20, 35, 48, 715, DateTimeKind.Local).AddTicks(108));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 9, 20, 35, 48, 715, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 9, 20, 35, 48, 715, DateTimeKind.Local).AddTicks(3941));

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleID",
                table: "UserRoles",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleID",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 8, 22, 2, 12, 702, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 8, 22, 2, 12, 702, DateTimeKind.Local).AddTicks(7276));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 8, 22, 2, 12, 702, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 8, 22, 2, 12, 703, DateTimeKind.Local).AddTicks(481));

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_UserID",
                table: "UserRoles",
                column: "UserID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
