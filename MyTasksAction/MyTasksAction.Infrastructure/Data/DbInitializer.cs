using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyTasksAction.Core.Entities;

namespace MyTasksAction.Infrastructure.Data;

public class DbInitializer
{
    private readonly ModelBuilder _builder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this._builder = modelBuilder;
    }

    public static async Task InsertDefaultUser(IServiceProvider serviceProvider)
    {
    }

    public static async Task CreateResourceUser(IServiceProvider serviceProvider, ApplicationUser applicationUser)
    {
        var userManager = serviceProvider.GetRequiredService<>()
      
    }
}

}