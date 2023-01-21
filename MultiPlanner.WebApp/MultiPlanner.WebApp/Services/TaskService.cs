using MultiPlanner.WebApp.Repositories;
using MultiPlanner.WebApp.Shared;

namespace MultiPlanner.WebApp.Services
{
    public interface ITaskService
    {
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
    }
}
