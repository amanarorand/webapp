using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAppEmpty.Models;

namespace WebAppEmpty.Controllers
{    
    public class DefaultController : ApiController
    {
        private IProductService productService;
        public DefaultController(IProductService productService)
        {
            this.productService = productService;
        }

        public string get()
        {
            productService.Add();
            return "test";
        }
        public IHttpActionResult get(int id)
        {
            return new TextResult("value", Request);
        }
    }

    public class TextResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;
        public TextResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            //var respone = new HttpResponseMessage()
            //{
            //    Content = _value,
            //    RequestMessage = _request
            //    , StatusCode = HttpStatusCode.OK
            //};
            var response = _request.CreateResponse(HttpStatusCode.OK, _value);
            return Task.FromResult(response);
        }
    }
}
