using MyTasksAction.Core.DTO;
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

    public DashboardTasks GetDashboard(string userId)
    {
        return new DashboardTasks(GetMyTasksAction(userId), GetAssignedTasksAction(userId) );

    }

    private List<TaskAction>  GetMyTasksAction(string userId)
    {
        return _taskActionRepository.GetByAsync(taskAction => taskAction.AssignTo == userId);
    }

    private List<TaskAction> GetAssignedTasksAction(string userId)
    {
        return _taskActionRepository.GetByAsync(taskAction => taskAction.AssignBy == userId);
    }


    public TaskAction Show(TaskAction taskAction)
    {
       return _taskActionRepository.ShowAsync(taskAction);    
    }

    public void Add(TaskAction taskAction)
    {
        _taskActionRepository.AddAsync(taskAction);
    }


    public void Remove(TaskAction taskAction)
    {
        _taskActionRepository.DeleteAsync(taskAction);
    }

    public void Update(TaskAction taskAction)
    {
        _taskActionRepository.UpdateAsync(taskAction);
    }
}
