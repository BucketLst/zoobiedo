using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace Zoobiedo.WebAPI.Helper
{
    public class HttpActionResult<T> : IHttpActionResult where T :class
    {
        private readonly string _value;
        private readonly HttpRequestMessage _request;
        T _obj=null;

        public HttpActionResult(HttpRequestMessage request, string value,T obj)
        {
            _request = request;
            _value = value;
            _obj = obj;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(CreateResponse(_request, _obj));
        }

        public HttpResponseMessage CreateResponse(HttpRequestMessage request, T value)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(new TestSerialize().Serialize<T>(new JsonMediaTypeFormatter(), value));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
