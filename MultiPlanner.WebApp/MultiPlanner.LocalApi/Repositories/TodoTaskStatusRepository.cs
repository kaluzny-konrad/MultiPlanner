using MultiPlanner.LocalApi.Shared;

namespace MultiPlanner.LocalApi.Repositories
{
    public interface ITodoTaskStatusRepository
    {
        IEnumerable<TodoTaskStatus> GetAll();
        TodoTaskStatus? GetById(int id);
        TodoTaskStatus? Add(TodoTaskStatus entity);
        TodoTaskStatus? Update(TodoTaskStatus entity);
        TodoTaskStatus? DeleteById(int id);
    }

    public class TodoTaskStatusRepository : ITodoTaskStatusRepository
    {
        private readonly LocalApiDbContext _dbContext;

        public TodoTaskStatusRepository
            (LocalApiDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IEnumerable<TodoTaskStatus> GetAll()
        {
            return _dbContext.TodoTaskStatuses;
        }

        public TodoTaskStatus? GetById(int id)
        {
            return _dbContext.TodoTaskStatuses
                .FirstOrDefault(e => e.TodoTaskStatusId == id);
        }

        public TodoTaskStatus? Add(TodoTaskStatus entity)
        {
            var addedEntity = _dbContext.TodoTaskStatuses.Add(entity);
            if (_dbContext.SaveChanges() > 0)
                return addedEntity.Entity;
            return null;
        }

        public TodoTaskStatus? Update(TodoTaskStatus entity)
        {
            var updatedEntity = GetById(entity.TodoTaskStatusId);
            if (updatedEntity == null) return null;
            if (_dbContext.SaveChanges() > 0)
                return updatedEntity;
            return null;
        }

        public TodoTaskStatus? DeleteById(int id)
        {
            var deletedEntity = GetById(id);
            if (deletedEntity == null) return null;
            _dbContext.TodoTaskStatuses.Remove(deletedEntity);
            if (_dbContext.SaveChanges() > 0)
                return deletedEntity;
            return null;
        }
    }
}
