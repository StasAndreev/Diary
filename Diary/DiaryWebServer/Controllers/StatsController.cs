using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DiaryDbAccess;

namespace DiaryWebServer.Controllers
{
    public class StatsController : ApiController
    {
        [Route("api/stats/{userId}/{weekStart}/{weekAmount}")]
        public Dictionary<TaskType, float> GetStats(Guid userId, DateTime weekStart, int weekAmount)
        {
            return Functions.SelectWeeklyStatistics(userId, weekStart, weekAmount);
        }
    }
}
