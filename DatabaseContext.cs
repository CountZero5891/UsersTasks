using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersTasks.Models;
using UsersTasks.Models.Enums;

namespace UsersTasks.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Objective>()
                .HasOne(p => p.Executor)
                .WithMany(t => t.ObjectivesExecutor)
                .HasForeignKey(p => p.ExecutorId);

            modelBuilder.Entity<Objective>()
                .HasOne(p => p.Director)
                .WithMany(t => t.ObjectivesDirector)
                .HasForeignKey(p => p.DirectorId);
          
            modelBuilder.Seed();
        }

       

    }
}
