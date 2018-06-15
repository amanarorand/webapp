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

        }
        public DbSet<User> Users { get; set; }
    }
}