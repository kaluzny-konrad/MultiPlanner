using MultiPlanner.WebApp.Shared;

namespace MultiPlanner.WebApp.Data
{
    public class TodoTaskOnList
    {
        public int TodoTaskId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public TaskStatuses Status { get; set; }
    }
}
