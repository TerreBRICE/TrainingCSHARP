using MyTasksAction.Core.Entities;
using MyTasksAction.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasksAction.Core.Services;

public class TaskActionService : ITaskActionService
{

    private readonly ITaskActionRepository _taskActionRepository;

    public TaskActionService(ITaskActionRepository taskActionRepository)
    {
        _taskActionRepository = taskActionRepository;
    }

    public void Add(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }
/*    public List<TaskAction> GetDashboardTask(string userId)
    {
        
    }*/

    private List<TaskAction> GetMyTasksAction(string userId)
    {
        return _taskActionRepository.GetByAsync(taskAction => taskAction.AssignTo == userId);
    }

    private List<TaskAction> GetAssignTasksAction(string userId)
    {
        return _taskActionRepository.GetByAsync(taskAction => taskAction.AssignTo == userId);
    }

    public List<TaskAction> GetTasksAction(string userId)
    {
        throw new NotImplementedException();
    }

    public void Remove(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }

    public void Update(TaskAction taskAction)
    {
        throw new NotImplementedException();
    }
}
