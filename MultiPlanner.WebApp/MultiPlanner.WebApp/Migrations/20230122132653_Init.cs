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
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTasks", x => x.TodoTaskId);
                });

            migrationBuilder.InsertData(
                table: "TodoTasks",
                columns: new[] { "TodoTaskId", "AddedDateTime", "ModifiedDateTime", "PlannedDeadline", "ShortDescription", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 22, 13, 26, 53, 586, DateTimeKind.Utc).AddTicks(1160), new DateTime(2023, 1, 22, 13, 26, 53, 586, DateTimeKind.Utc).AddTicks(1160), new DateTime(2023, 1, 24, 13, 26, 53, 586, DateTimeKind.Utc).AddTicks(1161), "test", 1, "test", new Guid("00000000-0000-0000-0000-000000000000") },
                    { 2, new DateTime(2023, 1, 22, 13, 26, 53, 586, DateTimeKind.Utc).AddTicks(1192), new DateTime(2023, 1, 22, 13, 26, 53, 586, DateTimeKind.Utc).AddTicks(1193), new DateTime(2023, 1, 27, 13, 26, 53, 586, DateTimeKind.Utc).AddTicks(1193), "test", 2, "test", new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoTasks");
        }
    }
}
