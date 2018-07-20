using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppEmpty.Models
{
    public class CustomDBContext : DbContext
    {
        public CustomDBContext() : base("custom")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CustomDBContext, WebAppEmpty.Migrations.Configuration>());
            
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
        }
    }
}