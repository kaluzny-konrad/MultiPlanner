using Microsoft.AspNetCore.Mvc;
using MultiPlanner.WebApp.Entities;
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

    public IActionResult Details(int todoTaskId)
    {
        var task = _todoTaskService.GetTask(todoTaskId);
        if (task == null) return RedirectToAction("NotFound", "Home");
        TaskDetailsViewModel taskDetails = new()
        {
            Task = task,
            Title = task.Title
        };
        return View("Details", taskDetails);
    }

    public IActionResult Update(int todoTaskId)
    {
        var task = _todoTaskService.GetTask(todoTaskId);
        if (task == null) return NotFound();

        try
        {
            var title = HttpContext.Request.Form["Title"].FirstOrDefault();
            if (title == null || title == "") ModelState.AddModelError("Title",
                    "Title should not be empty.");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            task.Title = title;

            var updatedTask = _todoTaskService.UpdateTask(task);
            if (updatedTask == null) return RedirectToAction("Index");
            TaskDetailsViewModel taskDetails = BuildTaskDetailsViewModel(updatedTask);
            return View("Details", taskDetails);
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
    }

    private static TaskDetailsViewModel BuildTaskDetailsViewModel(TodoTask? updatedTask)
    {
        return new()
        {
            Task = updatedTask,
            Title = updatedTask.Title
        };
    }
}
