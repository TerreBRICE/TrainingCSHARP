namespace MyTasksAction.Core.Interfaces;

public interface IUnitOfWork
{
    ITaskActionRepository GetTaskActionRepository();

    IApplicationUserRepository GetApplicationUserRepository();
    
    int Save();
}