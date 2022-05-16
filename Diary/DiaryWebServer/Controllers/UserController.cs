using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DiaryDbAccess;

namespace DiaryWebServer.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/user/{login}/{password}")]
        public HttpResponseMessage PostUser(string login, string password)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK); 
            User user = new User { Login = login, Password = password };
            response.Content = new StringContent(Functions.InsertUser(user).ToString());
            return response;
        }

        [Route("api/user/{login}/{password}")]
        public HttpResponseMessage GetUserId(string login, string password)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Functions.SelectUserId(login, password).ToString());
            return response;
        }
    }
}
