using System.Data.Common;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTasksAction.Core.Entities;
using MyTasksAction.Core.Interfaces;
using MyTasksAction.Core.Services;
using MyTasksAction.Infrastructure;
using MyTasksAction.Infrastructure.Data;

namespace MyTasksAction.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(WebApplication.CreateBuilder().Configuration
                    .GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ITaskActionService, TaskActionService>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<ITaskActionRepository, TaskActionRepository>();
        });

    }
}