using MultiPlanner.WebApp.Entities;
using MultiPlanner.WebApp.Repositories;

namespace MultiPlanner.WebApp.Services;

public interface ITaskService
{
    TodoTask? GetTask(int todoTaskId);
    IEnumerable<TodoTask> GetTasks(Guid userId);
}

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<TodoTask> GetTasks(Guid userId)
    {
        var result = _repository.GetAllByUserId(userId);
        return result;
    }

    public TodoTask? GetTask(int todoTaskId)
    {
        var result = _repository.GetById(todoTaskId);
        return result;
    }
}