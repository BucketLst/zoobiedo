using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Zoobiedo.Common.Models;
using Zoobiedo.ServiceLibrary;
using Zoobiedo.WebAPI.Helper;

namespace Zoobiedo.WebAPI.Controllers
{
    [RoutePrefix("ZoobiedoHOService/UserAccountAccess")]
    public class UserController : ApiController
    {
        private IUserAccount _userAccountObj = null;

        public UserController(IUserAccount usrAccObj)
        {
            _userAccountObj = usrAccObj;
        }
        static readonly IUserAccount usrAccObj = new UserAccountService();

        [Route("GetUser")]
        public async Task<IHttpActionResult> GetUser()
        {
            var userObject = await usrAccObj.GetUser();
            //return Ok(userObject);
            return new HttpActionResult<UserObjectModel>(null,string.Empty,userObject);
        }

        [Route("AuthenticateUser")]
        [HttpPost]
        public HttpResponseMessage AuthenticateUser(HttpRequestMessage request)
        {
            var result= request.Content.ReadAsStringAsync();
            return new HttpResponseMessage();
        }

        [Route("AutnticateUser")]
        [HttpPost]
        public bool IsUserAuthenticationPassesd()
        {
            return usrAccObj.IsUserAuthenticationPassesd();
        }
    }
}
