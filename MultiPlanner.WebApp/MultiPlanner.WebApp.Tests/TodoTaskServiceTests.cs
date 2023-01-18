using Moq;
using MultiPlanner.WebApp.Repositories;
using MultiPlanner.WebApp.Services;
using MultiPlanner.WebApp.Shared;

namespace MultiPlanner.WebApp.Tests;

public class TodoTaskServiceTests
{
    private static readonly Mock<ITodoTaskRepository> _repositoryMock = new();
    private readonly ITodoTaskService _service = new TodoTaskService(_repositoryMock.Object);
    private readonly List<TodoTask> _tasks = new() {
        new TodoTask { TodoTaskId = 1 },
        new TodoTask { TodoTaskId = 2 },
    };
    private readonly Guid _userId = Guid.NewGuid();

    [Test]
    public void GetTodoTasks_IfUserHasTasks_ReturnsAll()
    {
        _repositoryMock.Setup(r => r.GetAllByUserId(_userId)).Returns(_tasks);
        var result = _service.GetTodoTasks(_userId).ToList();
        Assert.That(result, Is.Not.Empty);
        Assert.That(result, Is.EqualTo(_tasks));
    }

    [Test]
    public void GetTodoTasks_IfUserHasNoTasks_ReturnsEmptyList()
    {
        _repositoryMock.Setup(r => r.GetAllByUserId(_userId)).Returns(new List<TodoTask>());
        var result = _service.GetTodoTasks(_userId).ToList();
        Assert.That(result, Is.Empty);
    }
}
