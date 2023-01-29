using MultiPlanner.WebApp.Entities;

namespace MultiPlanner.WebApp.DAL;

public interface ITaskRepository : IDisposable
{
    IEnumerable<TodoTask> GetAll();
    IEnumerable<TodoTask> GetAll(Guid userId);
    TodoTask? Get(int id);
    void Insert(TodoTask entity);
    void Update(TodoTask entity);
    void Delete(int id);
    bool Save();
}

public class TaskRepository : ITaskRepository, IDisposable
{
    private readonly MultiPlannerContext _context;
    private bool _disposed = false;

    public TaskRepository(MultiPlannerContext context) 
        => _context = context;

    public IEnumerable<TodoTask> GetAll()
    {
        return _context.TodoTasks.Select(entity => entity.ShallowCopy());
    }

    public IEnumerable<TodoTask> GetAll(Guid userId)
    {
        return _context.TodoTasks.Where(e => e.UserId == userId)
            .Select(t => t.ShallowCopy());
    }

    public TodoTask? Get(int id)
    {
        return _context.TodoTasks.Find(id)?.ShallowCopy();
    }

    public void Insert(TodoTask entity)
    {
        if (entity.TodoTaskId != 0) return;
        _context.TodoTasks.Add(entity);
    }

    public void Update(TodoTask entity)
    {
        var updatedEntity = _context.TodoTasks.Find(entity.TodoTaskId);
        if (updatedEntity == null) return;

        updatedEntity.Title = entity.Title;
        updatedEntity.ShortDescription = entity.ShortDescription;
        updatedEntity.PlannedDeadline = entity.PlannedDeadline;
        updatedEntity.Status = entity.Status;
        updatedEntity.ModifiedDateTime = DateTime.Now;
    }

    public void Delete(int id)
    {
        var RemovedEntity = _context.TodoTasks.Find(id);
        if (RemovedEntity == null) return;
        RemovedEntity.Status = TaskStatuses.Removed;
    }

    public bool Save()
    {
        return _context.SaveChanges() > 0;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
            _context.Dispose();
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}