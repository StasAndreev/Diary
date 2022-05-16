using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DiaryDbAccess;
using System.Text.Json;

namespace DiaryWebServer.Controllers
{
    public class RepeatRateController : ApiController
    {
        public HttpResponseMessage GetRepeatRates()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(Functions.SelectRepeatRates()));
            return response;
        }
    }
}
