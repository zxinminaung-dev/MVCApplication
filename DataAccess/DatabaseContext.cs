using Microsoft.EntityFrameworkCore;
using MVCApplication.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Claims;

namespace MVCApplication.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> option)
            :base(option) 
        { }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Class> Class { get; set; }
        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {        
            base.OnModelCreating(modelBuilder);
        }
    }
}
