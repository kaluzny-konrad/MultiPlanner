using Microsoft.AspNetCore.Mvc;
using MultiPlanner.WebApp.Models;
using MultiPlanner.WebApp.Services;

namespace MultiPlanner.WebApp.Controllers;

public class TasksController : Controller
{
    private readonly ITaskService _todoTaskService;

    public TasksController(ITaskService todoTaskService)
    {
        _todoTaskService = todoTaskService;
    }

    public IActionResult Index(Guid userId)
    {
        var todoTasks = _todoTaskService.GetTasks(userId).ToList();
        TasksViewModel todoTaskList = new()
        {
            Tasks = todoTasks
        };
        return View("Index", todoTaskList);
    }
}
