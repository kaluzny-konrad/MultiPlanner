namespace MultiPlanner.WebApp.Shared;

public class TodoTaskStatus
{
    public int TodoTaskStatusId { get; set; }
    public int TodoTaskId { get; set; }
    public DateTime AddedDateTime { get; set; }
    public TaskStatuses Status { get; set; }
}