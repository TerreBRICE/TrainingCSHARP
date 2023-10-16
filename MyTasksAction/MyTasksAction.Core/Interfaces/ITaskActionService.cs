using MyTasksAction.Core.Entities;

namespace MyTasksAction.Core.Interfaces;

public interface ITaskActionService
{
    List<TaskAction> GetTasksAction(string userId);

    void Add(TaskAction taskAction);
    void Remove(TaskAction taskAction);
    void Update(TaskAction taskAction);
}
