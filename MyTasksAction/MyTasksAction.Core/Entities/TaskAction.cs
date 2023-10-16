using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasksAction.Core.Entities;

public class TaskAction
{
    public string Id { get; set; }
    public string Title { get; set; }

    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int? Priority { get; set; }
    public string AssignBy { get; set; }
    public string AssignTo { get; set; }
    public string Status { get; set; }

    public TaskAction(string title, string? description, DateTime? dueDate, int? priority, string assignBy, string? assignTo, string status)
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

    public TaskAction()
    {
        
    }
}
