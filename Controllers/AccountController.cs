using System.Net.Http;
using System.Web.Http;
using WebAppEmpty.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Linq;
namespace WebAppEmpty.Controllers
{
    public class AccountController : ApiController
    {
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            var manager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new ApplicationUser() { Email = model.Email, UserName = model.Email };
            var result = await manager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }
            if (result.Errors != null)
            {
                result.Errors.ToList().ForEach((s) =>
                {
                    ModelState.AddModelError("", s);
                });
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}
