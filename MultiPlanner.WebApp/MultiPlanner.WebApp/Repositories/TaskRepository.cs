using MultiPlanner.WebApp.Entities;

namespace MultiPlanner.WebApp.Repositories;

public interface ITaskRepository
{
    IEnumerable<TodoTask> GetAll();
    IEnumerable<TodoTask> GetAllByUserId(Guid userId);
    TodoTask? GetById(int id);
    TodoTask? Add(TodoTask entity);
    TodoTask? Update(TodoTask entity);
    TodoTask? RemoveById(int id);
}

public class TaskRepository : ITaskRepository
{
    private readonly MultiPlannerDbContext _dbContext;

    public TaskRepository
        (MultiPlannerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<TodoTask> GetAll()
    {
        return _dbContext.TodoTasks.Select(t => t.ShallowCopy());
    }

    public IEnumerable<TodoTask> GetAllByUserId(Guid userId)
    {
        return _dbContext.TodoTasks.Where(e => e.UserId == userId)
            .Select(t => t.ShallowCopy());
    }

    public TodoTask? GetById(int id)
    {
        return GetByIdContext(id)?.ShallowCopy();
    }

    private TodoTask? GetByIdContext(int id)
    {
        return _dbContext.TodoTasks.FirstOrDefault(e => e.TodoTaskId == id);
    }

    public TodoTask? Add(TodoTask entity)
    {
        var addedEntity = _dbContext.TodoTasks.Add(entity);
        if (_dbContext.SaveChanges() > 0)
            return addedEntity.Entity?.ShallowCopy();
        return null;
    }

    public TodoTask? Update(TodoTask entity)
    {
        var updatedEntity = GetByIdContext(entity.TodoTaskId);
        if (updatedEntity == null) return null;

        updatedEntity.Title = entity.Title;
        updatedEntity.ShortDescription = entity.ShortDescription;
        updatedEntity.PlannedDeadline = entity.PlannedDeadline;
        updatedEntity.Status = entity.Status;
        updatedEntity.ModifiedDateTime = DateTime.Now;

        if (_dbContext.SaveChanges() > 0)
            return updatedEntity?.ShallowCopy();
        return null;
    }

    public TodoTask? RemoveById(int id)
    {
        var RemovedEntity = GetByIdContext(id);
        if (RemovedEntity == null) return null;

        RemovedEntity.Status = TaskStatuses.Removed;

        _dbContext.SaveChanges();
        return RemovedEntity?.ShallowCopy();
    }
}