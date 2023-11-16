using MyTasksAction.Core.Entities;
using MyTasksAction.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyTasksAction.UnitTests;

public class LocalTaskActionRepository : ITaskActionRepository
{
    static ApplicationUser user1 = new ApplicationUser("Dorian");
    static ApplicationUser user2 = new ApplicationUser("Sandrine");
    List<TaskAction> tasksAction;

    public LocalTaskActionRepository(ApplicationUser user)
    {
        generateTasksAction(user);
    }

    public void generateTasksAction(ApplicationUser user)
    {
        tasksAction = new List<TaskAction>()
        {
            new TaskAction("Tâche 1", "Tâche 1 description", null, null, user.Id, user1.Id, "EN COURS"),
            new TaskAction("Tâche 2", "Tâche 2 description", null, null, user2.Id,  user.Id, "EN COURS"),
            new TaskAction("Tâche 3", "Tâche 3 description", null, null, user2.Id,  user.Id, "EN COURS"),
            new TaskAction("Tâche 4", "Tâche 4 description", null, null, user.Id, user2.Id, "EN COURS"),
            new TaskAction("Tâche 5", "Tâche 5 description", null, null, user2.Id,  user.Id, "EN COURS"),
            new TaskAction("Tâche 6", "Tâche 6 description", null, null, user.Id, user2.Id, "EN COURS")
        };
    }

    public void AddAsync(TaskAction taskAction)
    {
        tasksAction.Add(taskAction);
    }

    public void DeleteAsync(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }

    public List<TaskAction> GetByAsync(Expression<Func<TaskAction, bool>> expression)
    {
        return tasksAction.Where(expression.Compile()).ToList();
    }

    public TaskAction ShowAsync(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }
}
