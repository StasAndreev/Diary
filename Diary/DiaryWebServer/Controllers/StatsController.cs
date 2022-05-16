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
    public class StatsController : ApiController
    {
        [Route("api/stats/{userId}/{weekStart}/{weekAmount}")]
        public HttpResponseMessage GetStats(Guid userId, DateTime weekStart, int weekAmount)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(
                Functions.SelectWeeklyStatistics(userId, weekStart, weekAmount)));
            return response;
        }
    }
}
