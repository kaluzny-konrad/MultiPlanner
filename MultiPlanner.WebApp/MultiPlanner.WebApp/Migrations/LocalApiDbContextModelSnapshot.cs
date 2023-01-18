﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiPlanner.WebApp.Repositories;

#nullable disable

namespace MultiPlanner.WebApp.Migrations
{
    [DbContext(typeof(LocalApiDbContext))]
    partial class LocalApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            ShortDescription = "test",
                            Title = "test",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            TodoTaskId = 2,
                            ShortDescription = "test",
                            Title = "test",
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("MultiPlanner.WebApp.Shared.TodoTaskStatus", b =>
                {
                    b.Property<int>("TodoTaskStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TodoTaskStatusId"));

                    b.Property<DateTime>("AddedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TodoTaskId")
                        .HasColumnType("int");

                    b.HasKey("TodoTaskStatusId");

                    b.ToTable("TodoTaskStatuses");

                    b.HasData(
                        new
                        {
                            TodoTaskStatusId = 1,
                            AddedDateTime = new DateTime(2023, 1, 17, 17, 47, 53, 560, DateTimeKind.Utc).AddTicks(5433),
                            Status = 1,
                            TodoTaskId = 1
                        },
                        new
                        {
                            TodoTaskStatusId = 2,
                            AddedDateTime = new DateTime(2023, 1, 18, 17, 47, 53, 560, DateTimeKind.Utc).AddTicks(5459),
                            Status = 2,
                            TodoTaskId = 1
                        },
                        new
                        {
                            TodoTaskStatusId = 3,
                            AddedDateTime = new DateTime(2023, 1, 18, 17, 47, 53, 560, DateTimeKind.Utc).AddTicks(5469),
                            Status = 1,
                            TodoTaskId = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}