using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MultiPlanner.WebApp.Entities;

public class TodoTask
{
    public int TodoTaskId { get; set; }

    public Guid UserId { get; set; } = Guid.NewGuid();

    [Required]
    [BindProperty]
    [StringLength(100, MinimumLength = 5)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [BindProperty]
    [StringLength(1000)]
    public string ShortDescription { get; set; } = string.Empty;

    public DateTime AddedDateTime { get; set; } = DateTime.Now;

    public DateTime ModifiedDateTime { get; set; } = DateTime.Now;

    [Required]
    [BindProperty]
    [DataType(DataType.DateTime)]
    public DateTime PlannedDeadline { get; set; } = DateTime.Now;

    [Required]
    [BindProperty]
    public TaskStatuses Status { get; set; } = TaskStatuses.ToDo;

    public TodoTask ShallowCopy()
    {
        return (TodoTask) MemberwiseClone();
    }
}