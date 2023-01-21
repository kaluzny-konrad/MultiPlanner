﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiPlanner.WebApp.Repositories;

#nullable disable

namespace MultiPlanner.WebApp.Migrations
{
    [DbContext(typeof(LocalApiDbContext))]
    [Migration("20230121135130_oneRepo")]
    partial class oneRepo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MultiPlanner.WebApp.Shared.TodoTask", b =>
                {
                    b.Property<int>("TodoTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TodoTaskId"));

                    b.Property<DateTime>("AddedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TodoTaskId");

                    b.ToTable("TodoTasks");

                    b.HasData(
                        new
                        {
                            TodoTaskId = 1,
                            AddedDateTime = new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7849),
                            ModifiedDateTime = new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7850),
                            ShortDescription = "test",
                            Status = 1,
                            Title = "test",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            TodoTaskId = 2,
                            AddedDateTime = new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7907),
                            ModifiedDateTime = new DateTime(2023, 1, 21, 13, 51, 30, 847, DateTimeKind.Utc).AddTicks(7908),
                            ShortDescription = "test",
                            Status = 2,
                            Title = "test",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}