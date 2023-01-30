using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MultiPlanner.WebApp.DAL;
using MultiPlanner.WebApp.Entities;
using MultiPlanner.WebApp.Models;

namespace MultiPlanner.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITaskRepository _repository;
    private readonly Guid _userId = Guid.Parse("00000000-0000-0000-0000-000000000000");

    public HomeController(ILogger<HomeController> logger, ITaskRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public IActionResult Index()
    {
        var entities = _repository
            .GetAll(_userId)
            .Where(e => e.Status != TaskStatuses.Removed)
            .ToList();
        var numberOfTasks = entities.Count();
        var numberOfSuccededTasks = entities
            .Where(e => e.Status == TaskStatuses.Success).Count();
        var numberOfOpenTasks = numberOfTasks - numberOfSuccededTasks;
        var viewModel = new HomeViewModel()
        {
            numberOfTasks = numberOfTasks,
            numberOfSuccededTasks = numberOfSuccededTasks,
            numberOfOpenTasks = numberOfOpenTasks,
        };
        return View("Index", viewModel);
    }

    public IActionResult NotFound(string message)
    {
        var notFoundViewModel = new NotFoundViewModel(message);
        return View("NotFound", notFoundViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
