using MyTasksAction.Core.Entities;
using System.Linq.Expressions;

namespace MyTasksAction.Core.Interfaces;

public interface ITaskActionRepository
{
    List<TaskAction> GetByAsync(Expression<Func<TaskAction,bool>> expression);
    void AddAsync(TaskAction taskAction);

    void UpdateAsync(TaskAction taskAction);

    Task DeleteAsync(TaskAction taskAction);
}
