using MyTasksAction.Core.Entities;

namespace MyTasksAction.Web.ViewModels;

public class DashboardTaskViewModel
{
    public List<TaskActionViewModel> MyTasksAction { get; set; }
    public List<TaskActionViewModel> AssignTasksAction { get; set; }

    public DashboardTaskViewModel(List<TaskActionViewModel> myTasksAction, List<TaskActionViewModel> assignTasksAction)
    {
        MyTasksAction = myTasksAction;
        AssignTasksAction = assignTasksAction;
    }
}