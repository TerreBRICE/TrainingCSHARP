using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasksAction.Core.Interfaces;

public interface ITaskActionRepository
{
    List<Task> GetAllAsync();
    void AddAsync(Task task);

    void UpdateAsync(Task task);

    Task DeleteAsync(Task task);
}
