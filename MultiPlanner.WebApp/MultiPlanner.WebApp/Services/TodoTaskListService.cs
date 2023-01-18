using MultiPlanner.WebApp.Data;

namespace MultiPlanner.WebApp.Services
{
    public interface ITodoTaskListService
    {
        List<TodoTaskOnList> GetTodoTaskList(Guid userId);
    }

    public class TodoTaskListService : ITodoTaskListService
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly ITodoTaskStatusService _todoTaskStatusService;

        public TodoTaskListService(ITodoTaskService todoTaskService,
            ITodoTaskStatusService todoTaskStatusService)
        {
            _todoTaskService = todoTaskService;
            _todoTaskStatusService = todoTaskStatusService;
        }

        public List<TodoTaskOnList> GetTodoTaskList(Guid userId)
        {
            var todoTasks = _todoTaskService.GetTodoTasks(userId);
            List<TodoTaskOnList> tasks = new();
            foreach (var todoTask in todoTasks)
            {
                var todoTaskStatus = _todoTaskStatusService
                    .GetNewestTodoTaskStatus(todoTask.TodoTaskId);
                if (todoTaskStatus != null)
                {
                    var task = new TodoTaskOnList()
                    {
                        TodoTaskId = todoTask.TodoTaskId,
                        Title = todoTask.Title,
                        ShortDescription = todoTask.ShortDescription,
                        Status = todoTaskStatus.Status
                    };
                    tasks.Add(task);
                }
            }
            return tasks;
        }
    }
}
