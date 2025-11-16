using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Athr.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removepemmission_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("267b1a91-bea9-4720-926e-1bb11925ff70"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("2e047611-6446-427c-b116-31545bf0d8bd"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("374ca149-e28d-4230-9c37-760e65d1dfc9"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("5853de59-dd78-4252-9125-e69fd8d451b8"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("b43a9f50-73ab-409e-b59c-44c48c4cb0fa"));

            migrationBuilder.DeleteData(
                table: "permissions",
                keyColumn: "id",
                keyValue: new Guid("c42bb008-d948-4424-9ee2-ba37c13d0182"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permissions",
                columns: new[] { "id", "admin_must_have", "name", "tags", "use_case", "user_must_have", "visible" },
                values: new object[,]
                {
                    { new Guid("267b1a91-bea9-4720-926e-1bb11925ff70"), false, "instructor.index", "[\"Business\",\"Instructor\"]", "instructor.index", false, true },
                    { new Guid("2e047611-6446-427c-b116-31545bf0d8bd"), false, "instructor.edit", "[\"Business\",\"Instructor\"]", "instructor.edit", false, true },
                    { new Guid("374ca149-e28d-4230-9c37-760e65d1dfc9"), false, "instructor.assign-permissions", "[\"Business\",\"Instructor\",\"Permissions\",\"Security\"]", "instructor.assign-permissions", false, true },
                    { new Guid("5853de59-dd78-4252-9125-e69fd8d451b8"), false, "instructor.add", "[\"Business\",\"Instructor\"]", "instructor.add", false, true },
                    { new Guid("b43a9f50-73ab-409e-b59c-44c48c4cb0fa"), false, "instructor.delete", "[\"Business\",\"Instructor\"]", "instructor.delete", false, true },
                    { new Guid("c42bb008-d948-4424-9ee2-ba37c13d0182"), false, "business.define-allowed-permissions", "[\"Business\",\"Instructor\",\"Permissions\",\"Security\"]", "business.define-allowed-permissions", false, true }
                });
        }
    }
}
