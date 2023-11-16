using MyTasksAction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasksAction.Core.Interfaces;

public interface IApplicationUserRepository
{
    Task<List<ApplicationUser>> ToListAsync();
}
