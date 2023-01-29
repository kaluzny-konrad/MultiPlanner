using Moq;
using Microsoft.AspNetCore.Mvc;

using MultiPlanner.WebApp.Entities;
using MultiPlanner.WebApp.Controllers;
using MultiPlanner.WebApp.Models;
using MultiPlanner.WebApp.DAL;

namespace MultiPlanner.WebApp.Tests
{
    public class TasksControllerTests
    {
        private static readonly Mock<ITaskRepository> _taskRepositoryMock = new();
        private readonly TasksController _controller = new(_taskRepositoryMock.Object);

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
            _taskRepositoryMock
                .Setup(r => r.GetAll(_userId))
                .Returns(_userTasks);
            var tasksCount = _userTasks.Count;

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
            _taskRepositoryMock
                .Setup(r => r.Get(todoTaskId))
                .Returns(_taskOne);

            var viewResult = _controller.Details(todoTaskId) as ViewResult;

            var model = viewResult?.Model as TaskDetailsViewModel;
            Assert.That(model, Is.Not.Null);
            Assert.That(model.TodoTaskId, Is.EqualTo(_taskOne.TodoTaskId));
            Assert.That(viewResult?.ViewName == "Details");
        }
    }
}