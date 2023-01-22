using MultiPlanner.WebApp.Entities;

namespace MultiPlanner.WebApp.Models;

public class TasksViewModel
{
    public List<TodoTask> Tasks { get; set; } = new();
}
