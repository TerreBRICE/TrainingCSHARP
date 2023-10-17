using Microsoft.AspNetCore.Mvc.Rendering;
using MyTasksAction.Core.Entities;

namespace MyTasksAction.Web.ViewModels;

public class TaskActionViewModel
{
    public string Id { get; set; }
    public string Title { get; set; }

    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int? Priority { get; set; }
    public string AssignBy { get; set; }
    public string AssignTo { get; set; }
    public string Status { get; set; }

    public SelectList userOptions { get; set; }

    public TaskActionViewModel(string title, string? description, DateTime? dueDate, int? priority, string assignBy, string? assignTo, string status)
    {
        Id = Guid.NewGuid().ToString();
        Title = title;
        Description = description == null ? "Description" : description;
        DueDate = dueDate;
        Priority = priority;
        AssignBy = assignBy;
        AssignTo = assignTo == null ? assignBy : assignTo;
        Status = status;
    }

    public TaskActionViewModel(List<TaskUser> taskUsers)
    {
        userOptions = new SelectList(taskUsers.Select(x => new SelectListItem(x.Name, x.Id)));
    }
}
