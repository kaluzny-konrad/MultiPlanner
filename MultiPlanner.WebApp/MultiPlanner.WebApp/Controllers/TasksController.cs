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
        var entities = _repository.GetAll(_userId).ToList();
        TasksViewModel entitiesIndex = new()
        {
            Tasks = entities
        };
        return View("Index", entitiesIndex);
    }

    // GET: /Tasks/Details/5
    [HttpGet]
    public IActionResult Details(int id)
    {
        var task = _repository.Get(id);
        if (task == null) return RedirectToAction("NotFound", "Home");
        var details = TaskDetailsViewModel.Build(task);
        return View("Details", details);
    }

    // GET: /Tasks/Create
    [HttpGet]
    public IActionResult Create()
    {
        var details = new TaskDetailsViewModel();
        return View("Details", details);
    }

    // POST: /Tasks/Update/5
    [HttpPost]
    public IActionResult Update(int id,
        [Bind(include: "Title, ShortDescription, PlannedDeadline, Status")]
        TaskDetailsViewModel viewModel)
    {
        if(viewModel.Title == "") ModelState.AddModelError("Title", "Title should not be empty.");

        try
        {
            var entity = _repository.Get(id);
            entity ??= new TodoTask() { UserId = _userId };

            if (ModelState.IsValid)
            {
                entity.Title = viewModel.Title;
                entity.ShortDescription = viewModel.ShortDescription;
                entity.PlannedDeadline = viewModel.PlannedDeadline;
                entity.Status = viewModel.Status;
                
                if (entity.TodoTaskId == 0)
                    _repository.Insert(entity);
                else
                    _repository.Update(entity);
                _repository.Save();
            }
            else
            {
                return View("Details", viewModel);
            }
        }
        catch (DataException)
        {
            ModelState.AddModelError(string.Empty, "Unable to save changes.");
            return View("Details", viewModel);
        }

        return RedirectToAction("Index");
    }

    // GET: /Tasks/Delete/5
    public ActionResult Delete(bool? saveChangesError = false, int id = 0)
    {
        if (saveChangesError.GetValueOrDefault())
        {
            ViewBag.ErrorMessage = "Delete failed, try again.";
        }
        var entity = _repository.Get(id);
        return View("Delete", entity);
    }

    // POST: /Tasks/Delete/5
    [HttpPost]
    public ActionResult Delete(int id)
    {
        try
        {
            _repository.Get(id);
            _repository.Delete(id);
            _repository.Save();
        }
        catch (DataException)
        {
            return RedirectToAction("Delete", new { id, saveChangesError = true });
        }
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        _repository.Dispose();
        base.Dispose(disposing);
    }
}
