using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultiPlanner.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoTasks",
                columns: table => new
                {
                    TodoTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTasks", x => x.TodoTaskId);
                });

            migrationBuilder.CreateTable(
                name: "TodoTaskStatuses",
                columns: table => new
                {
                    TodoTaskStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoTaskId = table.Column<int>(type: "int", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTaskStatuses", x => x.TodoTaskStatusId);
                });

            migrationBuilder.InsertData(
                table: "TodoTaskStatuses",
                columns: new[] { "TodoTaskStatusId", "AddedDateTime", "Status", "TodoTaskId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 17, 17, 47, 53, 560, DateTimeKind.Utc).AddTicks(5433), 1, 1 },
                    { 2, new DateTime(2023, 1, 18, 17, 47, 53, 560, DateTimeKind.Utc).AddTicks(5459), 2, 1 },
                    { 3, new DateTime(2023, 1, 18, 17, 47, 53, 560, DateTimeKind.Utc).AddTicks(5469), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "TodoTaskId", "ShortDescription", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "test", "test", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, "test", "test", new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTasks");

            migrationBuilder.DropTable(
                name: "TodoTaskStatuses");
        }
    }
}
