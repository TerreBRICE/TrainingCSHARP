using Microsoft.AspNetCore.Identity;
using MyTasksAction.Core.Entities;
using MyTasksAction.Core.Interfaces;

namespace MyTasksAction.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private ITaskActionRepository _taskActionRepository;
    private IApplicationUserRepository _applicationUserRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public ITaskActionRepository GetTaskActionRepository()
    {
        if (_taskActionRepository == null)
        {
            _taskActionRepository = new TaskActionRepository(_context);
        }

        return _taskActionRepository;
    }

    public IApplicationUserRepository GetApplicationUserRepository()
    {
        if (_applicationUserRepository == null)
        {
            _applicationUserRepository = new ApplicationUserRepository(_userManager, _context);
        }

        return _applicationUserRepository;
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}