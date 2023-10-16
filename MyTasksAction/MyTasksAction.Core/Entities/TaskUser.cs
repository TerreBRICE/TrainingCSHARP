using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasksAction.Core.Entities;

public class TaskUser
{
    public string Id { get; set; }
    public string Name { get; set; }

    public TaskUser(string name)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
    }
}
