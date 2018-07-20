using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using WebAppEmpty.Models;

namespace WebAppEmpty.Migration
{
    public class Configurartion : DbMigrationsConfiguration<CustomDBContext>
    {
        public Configurartion()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}