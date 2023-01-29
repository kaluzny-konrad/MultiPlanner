using Microsoft.AspNetCore.Mvc;
using MultiPlanner.WebApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace MultiPlanner.WebApp.Models;

public class TaskDetailsViewModel
{
    public int TodoTaskId { get; set; } = 0;

    [Required]
    [BindProperty]
    public string Title { get; set; } = string.Empty;

    [Required]
    [BindProperty]
    public string ShortDescription { get; set; } = string.Empty;

    [Required]
    [BindProperty]
    public DateTime PlannedDeadline { get; set; } = DateTime.Now;

    [Required]
    [BindProperty]
    public TaskStatuses Status { get; set; } = TaskStatuses.ToDo;

    public static TaskDetailsViewModel Build(TodoTask task)
    {
        var viewModel = new TaskDetailsViewModel
        {
            TodoTaskId = task.TodoTaskId,
            Title = task.Title,
            ShortDescription = task.ShortDescription,
            PlannedDeadline = task.PlannedDeadline,
            Status = task.Status,
        };

        return viewModel;
    }
}