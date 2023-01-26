using Microsoft.AspNetCore.Mvc;
using MultiPlanner.WebApp.Entities;

namespace MultiPlanner.WebApp.Models;

public class TaskDetailsViewModel
{
    public TodoTask Task { get; set; } = new();

    [BindProperty]
    public string Title { get; set; } = string.Empty;

    public static TaskDetailsViewModel Build(TodoTask task)
    {
        var viewModel = new TaskDetailsViewModel 
        { 
            Title = task.Title, 
            Task = task 
        };

        return viewModel;
    }
}