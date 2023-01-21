using Microsoft.AspNetCore.Mvc;
using MultiPlanner.WebApp.Data;
using MultiPlanner.WebApp.Services;

namespace MultiPlanner.WebApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _todoTaskService;

        public TasksController(ITaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }

        public TasksViewModel GetTasks(Guid userId)
        {
            var todoTasks = _todoTaskService.GetTasks(userId).ToList();
            TasksViewModel todoTaskList = new()
            {
                Tasks = todoTasks
            };
            return todoTaskList;
        }
    }
}
