using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DiaryDbAccess;

namespace DiaryWebServer.Controllers
{
    public class RepeatRateController : ApiController
    {
        public List<RepeatRate> GetRepeatRates()
        {
            return Functions.SelectRepeatRates();
        }
    }
}
