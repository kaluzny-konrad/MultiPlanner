using MultiPlanner.WebApp.Shared;

namespace MultiPlanner.WebApp.Repositories
{
    public interface ITodoTaskRepository
    {
        IEnumerable<TodoTask> GetAll();
        IEnumerable<TodoTask> GetAllByUserId(Guid userId);

        TodoTask? GetById(int id);
        TodoTask? Add(TodoTask entity);
        TodoTask? Update(TodoTask entity);
        TodoTask? DeleteById(int id);
    }

    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly LocalApiDbContext _dbContext;

        public TodoTaskRepository
            (LocalApiDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IEnumerable<TodoTask> GetAll()
        {
            return _dbContext.TodoTasks;
        }

        public IEnumerable<TodoTask> GetAllByUserId(Guid userId)
        {
            return _dbContext.TodoTasks
                .Where(e => e.UserId == userId);
        }

        public TodoTask? GetById(int id)
        {
            return _dbContext.TodoTasks
                .FirstOrDefault(e => e.TodoTaskId == id);
        }

        public TodoTask? Add(TodoTask entity)
        {
            var addedEntity = _dbContext.TodoTasks.Add(entity);
            if (_dbContext.SaveChanges() > 0)
                return addedEntity.Entity;
            return null;
        }

        public TodoTask? Update(TodoTask entity)
        {
            var updatedEntity = GetById(entity.TodoTaskId);
            if (updatedEntity == null) return null;
            if (_dbContext.SaveChanges() > 0)
                return updatedEntity;
            return null;
        }

        public TodoTask? DeleteById(int id)
        {
            var deletedEntity = GetById(id);
            if (deletedEntity == null) return null;
            _dbContext.TodoTasks.Remove(deletedEntity);
            if (_dbContext.SaveChanges() > 0)
                return deletedEntity;
            return null;
        }
    }
}
