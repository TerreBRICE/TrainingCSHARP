using MyTasksAction.Core.DTO;
using MyTasksAction.Core.Entities;
using MyTasksAction.Core.Interfaces;
using MyTasksAction.Core.Services;
using System.Runtime.Intrinsics.X86;

namespace MyTasksAction.UnitTests
{
    [TestClass]
    public class UnitTest
    {
        static TaskUser user = new TaskUser("Michelle");
        static ITaskActionRepository localTaskActionRepository = new LocalTaskActionRepository(user);
        TaskActionService taskActionService = new TaskActionService(localTaskActionRepository);

        [TestMethod]
        public void When_User1_Get_All_Dashboard_TaskAction_I_Should_See_Tasks_Assign_To_Me_And_Tasks_I_Assigned_To_Others()
        {

            DashboardTasks dashboard = taskActionService.GetDashboard(user.Id);

            Assert.AreEqual(3, dashboard.MyTasksAction.Count());
            Assert.AreEqual(3, dashboard.AssignTasksAction.Count());

        }

        [TestMethod]
        public void When_I_Assign_Task_To_A_User_I_Should_See_This_Task_In_My_Askings_And_User_Should_See_This_Task_In_My_Tasks()
        {
            TaskAction newTaskAction = new TaskAction("Tâche 6", "Tâche 6 description", null, null, new TaskUser("Elise").Id, user.Id,"EN COURS");
   
            taskActionService.Add(newTaskAction);

            DashboardTasks dashboard = taskActionService.GetDashboard(user.Id);

            Assert.AreEqual(4, dashboard.MyTasksAction.Count());
            Assert.AreEqual(3, dashboard.AssignTasksAction.Count());

        }
    }
}