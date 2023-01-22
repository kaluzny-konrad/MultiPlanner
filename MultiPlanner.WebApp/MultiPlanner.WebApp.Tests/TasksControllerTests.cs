using Moq;
using MultiPlanner.WebApp.Services;
using MultiPlanner.WebApp.Entities;
using MultiPlanner.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using MultiPlanner.WebApp.Models;

namespace MultiPlanner.WebApp.Tests
{
    public class TasksControllerTests
    {
        private static readonly Mock<ITaskService> _taskServiceMock = new();
        private readonly TasksController _controller = new(_taskServiceMock.Object);

        private static readonly Guid _userId = Guid.NewGuid();

        private static readonly TodoTask _taskOne = new()
        {
            TodoTaskId = 1,
            UserId = _userId,
            Title = "title",
            ShortDescription = "desc",
            AddedDateTime = DateTime.UtcNow,
            ModifiedDateTime = DateTime.UtcNow,
            Status = TaskStatuses.ToDo
        };

        private static readonly TodoTask _taskTwo = new()
        {
            TodoTaskId = 2,
            UserId = _userId,
            Title = "title",
            ShortDescription = "desc",
            AddedDateTime = DateTime.UtcNow,
            ModifiedDateTime = DateTime.UtcNow,
            Status = TaskStatuses.ToDo
        };

        private static readonly List<TodoTask> _userTasks = new () { _taskOne, _taskTwo };

        [Test]
        public void TasksController_GetTasks_Returns_TasksViewModel()
        {
            _taskServiceMock
                .Setup(r => r.GetTasks(_userId))
                .Returns(_userTasks);

            var viewResult = _controller.Index(_userId) as ViewResult;
            var model = viewResult?.Model as TasksViewModel;

            Assert.That(model, Is.Not.Null);
            Assert.That(model.Tasks, Has.Count.EqualTo(2));
        }

        [Test]
        public void TaskController_GetTasks_Returns_TasksIndexView()
        {
            _taskServiceMock
                .Setup(r => r.GetTasks(_userId))
                .Returns(_userTasks);

            var viewResult = _controller.Index(_userId) as ViewResult;

            Assert.That(viewResult?.ViewName == "Index");
        }
    }
}