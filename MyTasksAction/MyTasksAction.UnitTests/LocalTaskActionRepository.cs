using MyTasksAction.Core.Entities;
using MyTasksAction.Core.Interfaces;
using System.Linq.Expressions;

namespace MyTasksAction.UnitTests;

public class LocalTaskActionRepository : ITaskActionRepository
{
    static TaskUser user1 = new TaskUser("Dorian");
    static TaskUser user2 = new TaskUser("Sandrine");

    List<TaskAction> LocalTasksAction = new List<TaskAction>()
    {
        new TaskAction("Tâche 1", "Tâche 1 description", null, null, user1.Id, user2.Id, "EN COURS"),
        new TaskAction("Tâche 2", "Tâche 2 description", null, null, user2.Id, user2.Id, "EN COURS"),
        new TaskAction("Tâche 3", "Tâche 3 description", null, null, user2.Id, user1.Id, "EN COURS")
    };

    public void AddAsync(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }

    public List<TaskAction> GetByAsync(Expression expression)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }
}
