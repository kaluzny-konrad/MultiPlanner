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
        public void TasksController_Index_Returns_TasksView()
        {
            _taskServiceMock
                .Setup(r => r.GetTasks(_userId))
                .Returns(_userTasks);
            var tasksCount = _userTasks.Count();

            var viewResult = _controller.Index(_userId) as ViewResult;

            var model = viewResult?.Model as TasksViewModel;
            Assert.That(model, Is.Not.Null);
            Assert.That(model.Tasks, Has.Count.EqualTo(tasksCount));
            Assert.That(viewResult?.ViewName == "Index");
        }

        [Test]
        public void TasksController_Details_IfTaskExists_Returns_DetailsView()
        {
            var todoTaskId = _taskOne.TodoTaskId;
            _taskServiceMock
                .Setup(r => r.GetTask(todoTaskId))
                .Returns(_taskOne);

            var viewResult = _controller.Details(todoTaskId) as ViewResult;

            var model = viewResult?.Model as TaskDetailsViewModel;
            Assert.That(model, Is.Not.Null);
            Assert.That(model.Task, Is.EqualTo(_taskOne));
            Assert.That(viewResult?.ViewName == "Details");
        }
    }
}