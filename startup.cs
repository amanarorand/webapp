using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using WebAppEmpty.Providers;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Cors;
using WebAppEmpty.Models;
[assembly: OwinStartup(typeof(WebAppEmpty.Startup))]
namespace WebAppEmpty
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            var config = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                Provider = new ApplicationOAuthProvider(),
                AllowInsecureHttp = true
            };
            app.UseOAuthBearerTokens(config);            
        }
    }
}