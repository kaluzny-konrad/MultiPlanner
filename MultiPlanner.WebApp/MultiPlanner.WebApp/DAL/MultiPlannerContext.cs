using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiPlanner.WebApp.Entities;

namespace MultiPlanner.WebApp.DAL;

public class MultiPlannerContext : IdentityDbContext
{
    public MultiPlannerContext(DbContextOptions<MultiPlannerContext> options)
        : base(options) { }

    public DbSet<TodoTask> TodoTasks { get; set; }

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
                AddedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                Status = TaskStatuses.ToDo,
                PlannedDeadline = DateTime.UtcNow.AddDays(2),
            });

        modelBuilder.Entity<TodoTask>()
            .HasData(new TodoTask
            {
                TodoTaskId = 2,
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                Title = "test",
                ShortDescription = "test",
                AddedDateTime = DateTime.UtcNow,
                ModifiedDateTime = DateTime.UtcNow,
                Status = TaskStatuses.InProgress,
                PlannedDeadline = DateTime.UtcNow.AddDays(5),
            });
    }
}
