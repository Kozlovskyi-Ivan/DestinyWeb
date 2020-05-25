using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Destiny_back.Modules.EntityTypes;
using MySql.Data.EntityFrameworkCore;
using System.IO;

namespace Destiny_back.Modules
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Activity> Activites { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(File.ReadAllText(@"./DefaultConnection.txt"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Milestone>()
                .HasMany(m=>m.Activities)
                .WithOne(a=>a.Milestone)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Activity>()
                .HasMany(m=>m.Modifiers)
                .WithOne(a=>a.Activity)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
