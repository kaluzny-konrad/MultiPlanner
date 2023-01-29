using System.Data;
using Microsoft.AspNetCore.Mvc;

using MultiPlanner.WebApp.Entities;
using MultiPlanner.WebApp.Models;
using MultiPlanner.WebApp.DAL;

namespace MultiPlanner.WebApp.Controllers;

public class TasksController : Controller
{
    private readonly ITaskRepository _repository;
    private readonly Guid _userId = Guid.Parse("00000000-0000-0000-0000-000000000000");

    public TasksController(ITaskRepository repository) 
        => _repository = repository;

    // GET: /Tasks/
    [HttpGet]
    public IActionResult Index()
    {
        var entities = _repository
            .GetAll(_userId)
            .Where(e => e.Status != TaskStatuses.Removed)
            .ToList();
        return View("Index", entities);
    }

    // GET: /Tasks/Details/5
    [HttpGet]
    public IActionResult Details(int id)
    {
        var task = _repository.Get(id);
        if (task == null) return RedirectToAction("NotFound", "Home");
        return View("Details", task);
    }

    // POST: /Tasks/Details/5
    [HttpPost]
    public IActionResult Details(int id, [Bind] TodoTask todoTask)
    {
        todoTask.TodoTaskId = id;
        try
        {
            if (ModelState.IsValid)
            {
                if (todoTask.TodoTaskId == 0)
                {
                    todoTask.UserId = _userId;
                    _repository.Insert(todoTask);
                }
                else
                    _repository.Update(todoTask);
                _repository.Save();
                return RedirectToAction("Index");
            }
        }
        catch (DataException)
        {
            ModelState.AddModelError(string.Empty, "Unable to save changes.");
        }

        return View("Details", todoTask);
    }

    // GET: /Tasks/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View("Details", new TodoTask());
    }

    protected override void Dispose(bool disposing)
    {
        _repository.Dispose();
        base.Dispose(disposing);
    }
}
