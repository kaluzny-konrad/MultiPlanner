using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MultiPlanner.WebApp.DAL;
using MultiPlanner.WebApp.Entities;
using MultiPlanner.WebApp.Models;

namespace MultiPlanner.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITaskRepository _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly Guid _userId = default;
    private bool _isLoggedIn = false;

    public HomeController(ILogger<HomeController> logger, ITaskRepository repository, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
        {
            _userId = Guid.Parse(userId);
            _isLoggedIn = true;
        }
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
            isLoggedIn = _isLoggedIn,
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
