using Microsoft.EntityFrameworkCore;
using MultiPlanner.LocalApi.Shared;

namespace MultiPlanner.LocalApi.Repositories;

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
    }
}
