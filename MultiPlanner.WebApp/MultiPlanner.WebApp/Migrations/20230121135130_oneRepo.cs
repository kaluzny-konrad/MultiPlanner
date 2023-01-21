using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultiPlanner.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class oneRepo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTaskStatuses");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDateTime",
                table: "TodoTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "TodoTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "TodoTaskId",
                keyValue: 1,
                columns: new[] { "AddedDateTime", "ModifiedDateTime", "Status" },
                values: new object[] { new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7849), new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7850), 1 });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "TodoTaskId",
                keyValue: 2,
                columns: new[] { "AddedDateTime", "ModifiedDateTime", "Status" },
                values: new object[] { new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7907), new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7908), 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDateTime",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TodoTasks");

            migrationBuilder.CreateTable(
                name: "TodoTaskStatuses",
                columns: table => new
                {
                    TodoTaskStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TodoTaskId = table.Column<int>(type: "int", nullable: false)
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
        }
    }
}
