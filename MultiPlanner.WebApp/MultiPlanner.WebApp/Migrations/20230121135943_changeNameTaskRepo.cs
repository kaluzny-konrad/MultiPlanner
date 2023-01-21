﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiPlanner.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class changeNameTaskRepo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "TodoTaskId",
                keyValue: 1,
                columns: new[] { "AddedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7849), new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7850) });

            migrationBuilder.UpdateData(
                table: "TodoTasks",
                keyColumn: "TodoTaskId",
                keyValue: 2,
                columns: new[] { "AddedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7907), new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7908) });
        }
    }
}