using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTasksAction.Core.Entities;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace MyTasksAction.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            base.OnModelCreating(modelBuilder);
            //Property Configurations
            modelBuilder.Entity<TaskAction>()
                .HasOne<ApplicationUser>(task => task.Author)
                .WithMany(user => user.MyTasks)
                .HasForeignKey(task => task.AuthorId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<TaskAction>()
            .HasOne<ApplicationUser>(task => task.AssignToUser)
            .WithMany(user => user.AssignedTasks)
            .HasForeignKey(task => task.AssignTo)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        }
        public DbSet<TaskAction>? TaskAction { get; set; }
    }
}