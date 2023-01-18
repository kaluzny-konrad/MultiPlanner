namespace MultiPlanner.WebApp.Shared;

public class TodoTask
{
    public int TodoTaskId { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
}
