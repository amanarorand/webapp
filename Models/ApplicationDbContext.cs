using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace WebAppEmpty.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}