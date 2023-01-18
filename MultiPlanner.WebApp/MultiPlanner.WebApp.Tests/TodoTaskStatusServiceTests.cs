using Moq;
using MultiPlanner.WebApp.Repositories;
using MultiPlanner.WebApp.Services;
using MultiPlanner.WebApp.Shared;

namespace MultiPlanner.WebApp.Tests;

public class TodoTaskStatusServiceTests
{
    private static readonly Mock<ITodoTaskStatusRepository> _repositoryMock = new();
    private readonly ITodoTaskStatusService _service 
        = new TodoTaskStatusService(_repositoryMock.Object);

    private static readonly TodoTaskStatus _newestTaskStatus = new() 
        { TodoTaskId = 1, TodoTaskStatusId = 2, AddedDateTime = DateTime.UtcNow };

    private readonly List<TodoTaskStatus> _taskStatuses = new() {
        new TodoTaskStatus { TodoTaskId = 1, TodoTaskStatusId = 1, AddedDateTime = DateTime.UtcNow.AddSeconds(-1) },
        _newestTaskStatus,
        new TodoTaskStatus { TodoTaskId = 2, TodoTaskStatusId = 3, AddedDateTime = DateTime.UtcNow.AddSeconds(-2) },
    };

    [Test]
    public void GetNewestTodoTaskStatus_IfOne_ReturnIt()
    {
        var todoTaskId = 1;
        var exptectedTaskStatus = _newestTaskStatus;
        _repositoryMock.Setup(r => r.GetAllByTodoTaskId(todoTaskId))
            .Returns(_taskStatuses.Where(ts => ts.TodoTaskStatusId == _newestTaskStatus.TodoTaskStatusId));

        var result = _service.GetNewestTodoTaskStatus(todoTaskId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(exptectedTaskStatus));
    }

    [Test]
    public void GetNewestTodoTaskStatus_IfOne_ReturnNewest()
    {
        var todoTaskId = 1;
        var exptectedTaskStatus = _newestTaskStatus;
        _repositoryMock.Setup(r => r.GetAllByTodoTaskId(todoTaskId))
            .Returns(_taskStatuses.Where(ts => ts.TodoTaskId == todoTaskId));

        var result = _service.GetNewestTodoTaskStatus(todoTaskId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(exptectedTaskStatus));
    }
}
