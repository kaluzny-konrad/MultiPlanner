using MultiPlanner.WebApp.Repositories;
using MultiPlanner.WebApp.Shared;

namespace MultiPlanner.WebApp.Services
{
    public interface ITodoTaskService
    {
        IEnumerable<TodoTask> GetTodoTasks(Guid userId);
    }

    public class TodoTaskService : ITodoTaskService
    {
        private readonly ITodoTaskRepository _repository;

        public TodoTaskService(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TodoTask> GetTodoTasks(Guid userId)
        {
            var result = _repository.GetAllByUserId(userId);
            return result;
        }
    }
}
