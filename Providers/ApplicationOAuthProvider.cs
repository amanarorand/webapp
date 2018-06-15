using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace WebAppEmpty.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }
        public override  Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var identity = new ClaimsIdentity(context.Options.AuthenticationType, ClaimTypes.Name, context.UserName);
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));
            AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties() { });                      
            context.Validated(ticket);
            return base.GrantResourceOwnerCredentials(context);
        }
        public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            //setCorsPolicy(context.OwinContext);
            //if (context.Request.Method == "OPTIONS")
            //{
            //    context.RequestCompleted();
            //    return Task.FromResult(0);
            //}
            return base.MatchEndpoint(context);
        }
        private void setCorsPolicy(IOwinContext context)
        {
            string origin = context.Request.Headers.Get("Origin");
            //var found = list.Where(item => item == origin).Any();
            // if (found)
            //{
            if (origin != null)
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin",
                                             new string[] { "*" });
            }
            //}
            //context.Response.Headers.Add("Access-Control-Allow-Headers",
            //                      new string[] { "Authorization", "Content-Type" });
            context.Response.Headers.Add("Access-Control-Allow-Methods", new string[] { "*" });

        }
    }
}