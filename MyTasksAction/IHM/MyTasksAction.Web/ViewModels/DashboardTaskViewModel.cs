using MyTasksAction.Core.Entities;

namespace MyTasksAction.Web.ViewModels;

public class DashboardTaskViewModel
{
    List<TaskAction> MyTasksAction { get; set; }
    List<TaskAction> AssignTasksAction { get; set; }

    public DashboardTaskViewModel(List<TaskAction> myTasksAction, List<TaskAction> assignTasksAction)
    {
        MyTasksAction = myTasksAction;
        AssignTasksAction = assignTasksAction;
    }
}
