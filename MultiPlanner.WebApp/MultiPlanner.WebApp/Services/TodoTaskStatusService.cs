using MultiPlanner.WebApp.Repositories;
using MultiPlanner.WebApp.Shared;

namespace MultiPlanner.WebApp.Services
{
    public interface ITodoTaskStatusService
    {
        TodoTaskStatus? GetNewestTodoTaskStatus(int todoTaskId);
    }

    public class TodoTaskStatusService : ITodoTaskStatusService
    {
        private readonly ITodoTaskStatusRepository _repository;

        public TodoTaskStatusService(ITodoTaskStatusRepository repository)
        {
            _repository = repository;
        }

        public TodoTaskStatus? GetNewestTodoTaskStatus(int todoTaskId)
        {
            var todoTaskStatuses = _repository.GetAllByTodoTaskId(todoTaskId);
            var result = todoTaskStatuses
                .OrderByDescending(ts => ts.AddedDateTime)
                .FirstOrDefault();
            return result;
        }
    }
}
