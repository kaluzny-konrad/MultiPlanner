using MultiPlanner.WebApp.Entities;
using MultiPlanner.WebApp.Repositories;

namespace MultiPlanner.WebApp.Services;

public interface ITaskService
{
    TodoTask? RemoveTask(int todoTaskId);
    TodoTask? GetTask(int todoTaskId);
    TodoTask? UpdateTask(TodoTask todoTask);
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

    public TodoTask? RemoveTask(int todoTaskId)
    {
        var result = _repository.RemoveById(todoTaskId);
        return result;
    }

    public TodoTask? UpdateTask(TodoTask todoTask)
    {
        var result = _repository.Update(todoTask);
        return result;
    }
}