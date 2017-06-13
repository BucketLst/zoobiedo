using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Zoobiedo.WebAPI.Helper;

namespace Zoobiedo.Helper
{
   public static class HttpRequestMessageExtensions
    {
      public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage request, HttpStatusCode statusCode, T value)
        {
            /*  IContentNegotiator negotiator = Configuration.Services.GetContentNegotiator();

              ContentNegotiationResult result = negotiator.Negotiate(
                  typeof(T), request, Configuration.Formatters);
              if (result == null)
              {
                  var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                  throw new HttpResponseException(response);
              }

              return new HttpResponseMessage()
              {
                  Content = new ObjectContent<T>(
                      value,                // What we are serializing 
                      result.Formatter,           // The media formatter
                      result.MediaType.MediaType  // The MIME type
                  )
              };*/
            var response = new HttpResponseMessage();
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Content = new StringContent(new TestSerialize().Serialize<T>(new JsonMediaTypeFormatter(),value));
            response.EnsureSuccessStatusCode();
            return response;
        }

       
    }
}

