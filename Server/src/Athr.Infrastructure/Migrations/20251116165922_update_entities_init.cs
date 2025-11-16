using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Athr.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_entities_init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dialCode_id",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "SA");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Country IsoCode"),
                    dial_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "qualifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_qualifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trace_logs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    table_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    entry_string = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    interception_unique_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    old_values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    new_values = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    affected_columns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primary_key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trace_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country_names",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    culture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    is_default = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_country_names", x => x.id);
                    table.ForeignKey(
                        name: "fk_country_names_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_country_names_country_id",
                table: "country_names",
                column: "country_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "country_names");

            migrationBuilder.DropTable(
                name: "qualifications");

            migrationBuilder.DropTable(
                name: "trace_logs");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropColumn(
                name: "dialCode_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "users");
        }
    }
}
