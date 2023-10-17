using MyTasksAction.Core.Entities;
using MyTasksAction.Core.Interfaces;
using MyTasksAction.Infrastructure.Data;
using System.Linq.Expressions;

namespace MyTasksAction.Infrastructure
{
    public class TaskActionRepository : ITaskActionRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public TaskActionRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void AddAsync(TaskAction taskAction)
        {
            applicationDbContext.TaskAction.Add(taskAction);
            applicationDbContext.SaveChanges();
        }

        public Task DeleteAsync(TaskAction taskAction)
        {
            throw new NotImplementedException();
        }

        public List<TaskAction> GetByAsync(Expression<Func<TaskAction, bool >> expression)
        {
            return applicationDbContext.TaskAction.Where(expression).ToList();
        }

        public TaskAction ShowAsync(TaskAction taskAction)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(TaskAction taskAction)
        {
            throw new NotImplementedException();
        }

        void ITaskActionRepository.DeleteAsync(TaskAction taskAction)
        {
            throw new NotImplementedException();
        }
    }
}