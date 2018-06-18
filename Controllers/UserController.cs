using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppEmpty.Models;
using WebAppEmpty.Providers;
using WebAppEmpty.Services;

namespace WebAppEmpty.Controllers
{
    public class UserController : ApiController
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        //[HttpPost]
        //[Route("User/Create")]
        //[CustomAuthorizationFilter()]
        [Authorize()]
        public HttpResponseMessage Post(User user)
        {
            System.Threading.Thread.Sleep(5000);
            if (userService.IsUserExits(user.Email))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Resources.User.MsgAlreadyPresent);
            }
            else
            {
                userService.AddUser(user);
                return Request.CreateResponse(HttpStatusCode.OK, Resources.User.MsgUserCreated);
            }
        }     
        public IEnumerable<User> Get()
        {
            return userService.getAll();          
        }
        public User Get(int id)
        {
            return userService.get(id);            
        }
    }
}
