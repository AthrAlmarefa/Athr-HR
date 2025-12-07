using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Athr.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TaskWorkDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "task_works",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    priorityvalue = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    prioritykey = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    deletedat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    deletedby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_works", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task_works");
        }
    }
}
