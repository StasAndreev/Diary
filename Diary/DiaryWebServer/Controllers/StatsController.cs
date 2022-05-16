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
        [Route("api/stats/{userId}/{weekAmount}")]
        public HttpResponseMessage GetStats(string userId, [FromBody] DateTime weekStart, int weekAmount)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(
                Functions.SelectWeeklyStatistics(Guid.Parse(userId), weekStart, weekAmount)));
            return response;
        }
    }
}
