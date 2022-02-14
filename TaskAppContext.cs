using Microsoft.EntityFrameworkCore;
using TaskManager.Entities;

namespace TaskManager
{
    public class TaskAppContext : DbContext
    {
       
            public DbSet<ProjectEntity> Projects { get; set; }
            public DbSet<TaskEntity> Tasks { get; set; }


            public TaskAppContext(DbContextOptions<TaskAppContext> options)
           : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<ProjectEntity>()
                        .HasMany(p => p.ProjectTasks)
                        .WithOne(t => t.ProjectEntity)
                        .OnDelete(DeleteBehavior.Cascade);
            }
        }
    
}
