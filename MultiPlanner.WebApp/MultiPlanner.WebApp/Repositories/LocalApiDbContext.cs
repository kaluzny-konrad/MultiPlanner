using Microsoft.EntityFrameworkCore;
using MultiPlanner.WebApp.Shared;

namespace MultiPlanner.WebApp.Repositories;

public class LocalApiDbContext : DbContext
{
    public LocalApiDbContext
        (DbContextOptions<LocalApiDbContext> options)
    : base(options) { }

    public DbSet<TodoTask> TodoTasks { get; set; }
    public DbSet<TodoTaskStatus> TodoTaskStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoTask>()
            .HasData(new TodoTask
            {
                TodoTaskId = 1,
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                Title = "test",
                ShortDescription = "test",
            });

        modelBuilder.Entity<TodoTask>()
            .HasData(new TodoTask
            {
                TodoTaskId = 2,
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                Title = "test",
                ShortDescription = "test",
            });

        modelBuilder.Entity<TodoTaskStatus>()
            .HasData(new TodoTaskStatus
            {
                TodoTaskStatusId = 1,
                TodoTaskId = 1,
                AddedDateTime = DateTime.UtcNow.AddDays(-1),
                Status = TaskStatuses.ToDo
            });

        modelBuilder.Entity<TodoTaskStatus>()
            .HasData(new TodoTaskStatus
            {
                TodoTaskStatusId = 2,
                TodoTaskId = 1,
                AddedDateTime = DateTime.UtcNow,
                Status = TaskStatuses.InProgress
            });

        modelBuilder.Entity<TodoTaskStatus>()
            .HasData(new TodoTaskStatus
            {
                TodoTaskStatusId = 3,
                TodoTaskId = 2,
                AddedDateTime = DateTime.UtcNow,
                Status = TaskStatuses.ToDo
            });
    }
}
