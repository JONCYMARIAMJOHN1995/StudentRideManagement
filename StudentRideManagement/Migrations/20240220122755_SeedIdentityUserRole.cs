using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRideManagement.Migrations
{
    public partial class SeedIdentityUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904867f7-215d-4ebe-bd5b-77738bb6b73e",
                column: "ConcurrencyStamp",
                value: "e7dc2d85-d7a0-4bec-b38e-e66e961893e2");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "904867f7-215d-4ebe-bd5b-77738bb6b73e", "66350743-bfba-45b6-9502-9307f954370d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66350743-bfba-45b6-9502-9307f954370d",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66c7c787-9cdc-4d4a-9b18-37e93cfb7753", new DateTime(2024, 2, 20, 17, 57, 55, 443, DateTimeKind.Local).AddTicks(2836), "AQAAAAEAACcQAAAAEHUxEayy5oGKC5g49s+NpFP7O8ynFEFVuLHLdMLB/LJQOdYlc/5H5tbv8OgdfU3Rog==", "25a375b2-cf7c-43d8-a707-bf4950c5e690" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "ValidFrom",
                value: new DateTime(2024, 2, 20, 17, 57, 55, 444, DateTimeKind.Local).AddTicks(7790));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "904867f7-215d-4ebe-bd5b-77738bb6b73e", "66350743-bfba-45b6-9502-9307f954370d" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904867f7-215d-4ebe-bd5b-77738bb6b73e",
                column: "ConcurrencyStamp",
                value: "207ec7e9-8a75-4b07-8acc-40ae447cbd28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66350743-bfba-45b6-9502-9307f954370d",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe29d09c-0abc-44c7-a530-6f2822243b3c", new DateTime(2024, 2, 20, 17, 47, 40, 329, DateTimeKind.Local).AddTicks(2899), "AQAAAAEAACcQAAAAEFImIFVJ1cN4CMs0i1uOkaR8+f1UAT0mZEBWShdhwYtLTqW2HbkL3ZNb0u7Ar+8axA==", "ddc663b4-2e49-42fc-8108-739c5992bb8d" });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "ValidFrom",
                value: new DateTime(2024, 2, 20, 17, 47, 40, 330, DateTimeKind.Local).AddTicks(7563));
        }
    }
}
