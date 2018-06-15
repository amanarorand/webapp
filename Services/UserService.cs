using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppEmpty.Models;

namespace WebAppEmpty.Services
{
    public class UserService : IUserService
    {
        public void AddUser(User user)
        {
            using (var context = new CustomDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<User> getAll()
        {
            using (var context = new CustomDBContext())
            {
                var data = context.Users.ToList().AsEnumerable();
                return data;          
            }
        }

        public bool IsUserExits(string email)
        {
            using (var context = new CustomDBContext())
            {
                return context.Users.Where(p => p.Email == email).Count() == 1;                
            }
        }

    }

    public interface IUserService
    {
        void AddUser(User user);
        bool IsUserExits(string email);

        IEnumerable<User> getAll();
    }
}