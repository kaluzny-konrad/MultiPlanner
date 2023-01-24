using MultiPlanner.WebApp.Entities;

namespace MultiPlanner.WebApp.Models;

public class TaskDetailsViewModel
{
    public TodoTask Task { get; set; } = new();
}
