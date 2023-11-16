using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTasksAction.Core.Entities;
using MyTasksAction.Core.Interfaces;
using MyTasksAction.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyTasksAction.Infrastructure;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly UserManager<ApplicationUser> _userRepository;
    private readonly ApplicationDbContext _context;

    public ApplicationUserRepository(UserManager<ApplicationUser> userRepository, ApplicationDbContext context)
    {
        _userRepository = userRepository;
        _context = context;
    }

    public async Task<List<ApplicationUser>> ToListAsync()
    {
        return await _context.Users.ToListAsync();
    }
}
