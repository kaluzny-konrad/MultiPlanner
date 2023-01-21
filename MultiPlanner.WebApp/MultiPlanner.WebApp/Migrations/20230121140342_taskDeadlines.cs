using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPlanner.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class taskDeadlines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedDeadline",
                table: "TodoTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "TodoTaskId",
                keyValue: 1,
                columns: new[] { "AddedDateTime", "ModifiedDateTime", "PlannedDeadline" },
                values: new object[] { new DateTime(2023, 1, 21, 14, 3, 42, 491, DateTimeKind.Utc).AddTicks(9804), new DateTime(2023, 1, 21, 14, 3, 42, 491, DateTimeKind.Utc).AddTicks(9805), new DateTime(2023, 1, 23, 14, 3, 42, 491, DateTimeKind.Utc).AddTicks(9805) });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "TodoTaskId",
                keyValue: 2,
                columns: new[] { "AddedDateTime", "ModifiedDateTime", "PlannedDeadline" },
                values: new object[] { new DateTime(2023, 1, 21, 14, 3, 42, 491, DateTimeKind.Utc).AddTicks(9836), new DateTime(2023, 1, 21, 14, 3, 42, 491, DateTimeKind.Utc).AddTicks(9837), new DateTime(2023, 1, 26, 14, 3, 42, 491, DateTimeKind.Utc).AddTicks(9837) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedDeadline",
                table: "TodoTasks");

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "TodoTaskId",
                keyValue: 1,
                columns: new[] { "AddedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 1, 21, 13, 59, 43, 32, DateTimeKind.Utc).AddTicks(9401), new DateTime(2023, 1, 21, 13, 59, 43, 32, DateTimeKind.Utc).AddTicks(9402) });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "TodoTaskId",
                keyValue: 2,
                columns: new[] { "AddedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 1, 21, 13, 59, 43, 32, DateTimeKind.Utc).AddTicks(9429), new DateTime(2023, 1, 21, 13, 59, 43, 32, DateTimeKind.Utc).AddTicks(9429) });
        }
    }
}
