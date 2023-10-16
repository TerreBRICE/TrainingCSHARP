using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasksAction.Core.Interfaces;

public interface ITaskActionService
{
    List<Task> GetTasksAction(string userId);
    List<Task> GetMyTasksAction(string userId);
    List<Task> GetAssignedTasksAction(string userId);

    void AddTaskAction(Task task);
    void RemoveTaskAction(Task task);
    void UpdateTaskAction(Task task);
    Task GetTaskActionById(string id);
}
