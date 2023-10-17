using MyTasksAction.Core.Entities;
using System.Linq.Expressions;

namespace MyTasksAction.Core.Interfaces;

public interface ITaskActionRepository
{
    List<TaskAction> GetByAsync(Expression<Func<TaskAction,bool>> expression);
    TaskAction ShowAsync(TaskAction taskAction);
    void AddAsync(TaskAction taskAction);

    void UpdateAsync(TaskAction taskAction);

    void DeleteAsync(TaskAction taskAction);
}
