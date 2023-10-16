using MyTasksAction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasksAction.Core.DTO;

public class DashboardTasks
{
    List<TaskAction> MyTasksAction { get; set; }
    List<TaskAction> AssignTasksAction { get; set; }

    public DashboardTasks(List<TaskAction> myTasksAction, List<TaskAction> assignTasksAction)
    {
        MyTasksAction = myTasksAction;
        AssignTasksAction = assignTasksAction;
    }
}
