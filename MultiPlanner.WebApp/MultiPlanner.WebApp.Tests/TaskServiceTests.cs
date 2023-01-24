using Moq;
using MultiPlanner.WebApp.Repositories;
using MultiPlanner.WebApp.Services;
using MultiPlanner.WebApp.Entities;

namespace MultiPlanner.WebApp.Tests;

public class TaskServiceTests
{
    private static readonly Mock<ITaskRepository> _repositoryMock = new();
    private readonly ITaskService _service = new TaskService(_repositoryMock.Object);
    private readonly List<TodoTask> _tasks = new() {
        new TodoTask { TodoTaskId = 1 },
        new TodoTask { TodoTaskId = 2 },
    };
    private readonly Guid _userId = Guid.NewGuid();

    [Test]
    public void TaskService_GetTasks_IfUserHasTasks_ReturnsAll()
    {
        _repositoryMock.Setup(r => r.GetAllByUserId(_userId)).Returns(_tasks);
        var result = _service.GetTasks(_userId).ToList();
        Assert.That(result, Is.Not.Empty);
        Assert.That(result, Is.EqualTo(_tasks));
    }

    [Test]
    public void TaskService_GetTasks_IfUserHasNoTasks_ReturnsEmptyList()
    {
        _repositoryMock.Setup(r => r.GetAllByUserId(_userId)).Returns(new List<TodoTask>());
        var result = _service.GetTasks(_userId).ToList();
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void TaskService_GetTask_IfExists_ReturnsTask()
    {
        var task = _tasks.First();
        _repositoryMock.Setup(r => r.GetById(task.TodoTaskId)).Returns(task);
        var result = _service.GetTask(task.TodoTaskId);
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(task));
    }

    [Test]
    public void TaskService_GetTask_IfNotExists_ReturnsNull()
    {
        var task = _tasks.First();
        _repositoryMock.Setup(r => r.GetById(task.TodoTaskId)).Returns(value: null);
        var result = _service.GetTask(task.TodoTaskId);
        Assert.That(result, Is.Null);
    }
}
