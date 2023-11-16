using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasksAction.Core.Entities;

public class ApplicationUser: IdentityUser
{
  

    public virtual List<TaskAction> AssignedTasks { get; set; } = new();
    public virtual List<TaskAction> MyTasks { get; set; } = new();

    public ApplicationUser(string userName) :base(userName)
    {
       
    }

    public ApplicationUser()
    {
        
    }
}
