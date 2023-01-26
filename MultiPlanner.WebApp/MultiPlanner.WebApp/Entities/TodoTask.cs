using Microsoft.AspNetCore.Mvc;

namespace MultiPlanner.WebApp.Entities;

public class TodoTask
{
    public int TodoTaskId { get; set; }

    public Guid UserId { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public DateTime AddedDateTime { get; set; } = DateTime.Now;

    public DateTime ModifiedDateTime { get; set; } = DateTime.Now;

    public DateTime PlannedDeadline { get; set; } = DateTime.Now;

    public TaskStatuses Status { get; set; } = TaskStatuses.ToDo;

    public TodoTask ShallowCopy()
    {
        return (TodoTask) MemberwiseClone();
    }
}