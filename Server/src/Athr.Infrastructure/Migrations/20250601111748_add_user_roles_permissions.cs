using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Athr.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_user_roles_permissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "businessRoles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_verified = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    identity_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_at_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_business_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    use_case = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_must_have = table.Column<bool>(type: "bit", nullable: false),
                    user_must_have = table.Column<bool>(type: "bit", nullable: false),
                    visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    mid_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    identity_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    identity_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_at_utc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "business_allowed_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    permission_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    business_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_business_allowed_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_business_allowed_permissions_business_roles_business_id",
                        column: x => x.business_id,
                        principalTable: "businessRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_businesses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    business_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_businesses", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_businesses_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles_permissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    permission_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    business_role_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_roles_permissions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "ix_business_allowed_permissions_business_id",
                table: "business_allowed_permissions",
                column: "business_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_businesses_user_id",
                table: "user_businesses",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_permissions_user_id",
                table: "user_roles_permissions",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "business_allowed_permissions");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "user_businesses");

            migrationBuilder.DropTable(
                name: "user_roles_permissions");

            migrationBuilder.DropTable(
                name: "businessRoles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
