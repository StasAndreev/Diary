using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using DiaryDbAccess;

namespace DiaryWebServer.Controllers
{
    public class RepeatRateController : ApiController
    {
        public HttpResponseMessage GetRepeatRates()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content
            return response;
        }
    }
}
