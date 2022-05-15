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
        public int PostUser(string login, string password)
        {
            User user = new User { Login = login, Password = password };
            return Functions.InsertUser(user);
        }

        public int GetUserId(string login, string password)
        {
            return Functions.SelectUserId(login, password);
        }
    }
}
