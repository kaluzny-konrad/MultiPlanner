using Moq;
using MultiPlanner.WebApp.Services;
using MultiPlanner.WebApp.Shared;
using MultiPlanner.WebApp.Data;

namespace MultiPlanner.WebApp.Tests
{
    public class TodoTaskListServiceTests
    {
        private static readonly Mock<ITodoTaskService> _todoTaskServiceMock = new();
        private static readonly Mock<ITodoTaskStatusService> _todoTaskStatusServiceMock = new();
        private readonly ITodoTaskListService _service 
            = new TodoTaskListService(_todoTaskServiceMock.Object, _todoTaskStatusServiceMock.Object);

        private static readonly Guid _userId = Guid.NewGuid();

        private static readonly TodoTaskStatus _taskStatusOne = new()
            { TodoTaskId = 1, TodoTaskStatusId = 123, AddedDateTime = DateTime.UtcNow };
        private static readonly TodoTask _taskOne = new() 
            { TodoTaskId = 1, UserId = _userId, Title = "title", ShortDescription = "desc" };

        private static readonly TodoTaskStatus _taskStatusTwo = new()
            { TodoTaskId = 2, TodoTaskStatusId = 124, AddedDateTime = DateTime.UtcNow };
        private static readonly TodoTask _taskTwo = new()
            { TodoTaskId = 2, UserId = _userId, Title = "title", ShortDescription = "desc" };

        private static readonly List<TodoTask> _userTasks = new () { _taskOne, _taskTwo };

        [Test]
        public void GetTodoTaskList_Returns_ListForUser()
        {
            _todoTaskServiceMock
                .Setup(r => r.GetTodoTasks(_userId))
                .Returns(_userTasks);
            _todoTaskStatusServiceMock
                .Setup(r => r.GetNewestTodoTaskStatus(_taskOne.TodoTaskId))
                .Returns(_taskStatusOne);
            _todoTaskStatusServiceMock
                .Setup(r => r.GetNewestTodoTaskStatus(_taskTwo.TodoTaskId))
                .Returns(_taskStatusTwo);

            List<TodoTaskOnList> tasks = _service.GetTodoTaskList(_userId);

            Assert.That(tasks, Has.Count.EqualTo(2));
        }
    }
}