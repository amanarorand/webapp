using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace WebAppEmpty.Infrastructure.MessageHandlers
{
    public class CustomDelegateHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> authHeaderValues = null;
            request.Headers.TryGetValues("Authorization", out authHeaderValues);
            if (authHeaderValues == null)
            {
                return base.SendAsync(request, cancellationToken);
            }
            var tokens = authHeaderValues.FirstOrDefault();
            tokens = tokens.Replace("Basic", "").Trim();
            if (!string.IsNullOrEmpty(tokens))
            {
                var token_values = tokens.Split(':');

            }
            else
            {
                var respone = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                return Task.FromResult(respone);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}