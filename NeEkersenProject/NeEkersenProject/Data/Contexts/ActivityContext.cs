using Microsoft.EntityFrameworkCore;
using NeEkersenProject.Data.Configurations;
using NeEkersenProject.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeEkersenProject.Data.Contexts
{
    public class ActivityContext : DbContext
    {
        public ActivityContext(DbContextOptions options) : base(options) { }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
         //   modelBuilder.Entity<Activity>().Property(x=>x.Id).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}
