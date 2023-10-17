using MyTasksAction.Core.DTO;
using MyTasksAction.Core.Entities;

namespace MyTasksAction.Core.Interfaces;

public interface ITaskActionService
{
    DashboardTasks GetDashboard(string userId);

    TaskAction Show(TaskAction taskAction);
    void Add(TaskAction taskAction);
    void Remove(TaskAction taskAction);
    void Update(TaskAction taskAction);
}
