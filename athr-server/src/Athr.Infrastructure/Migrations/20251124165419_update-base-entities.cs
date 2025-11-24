using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Athr.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatebaseentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "qualifications");

            migrationBuilder.DropTable(
                name: "trace_logs");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "users");
        }
    }
}
