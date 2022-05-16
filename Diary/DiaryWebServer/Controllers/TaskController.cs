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
    public class TaskController : ApiController
    {
        public HttpResponseMessage GetWeekTasks(string userId, [FromBody] DateTime weekStart)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            List<Task> result = new List<Task>();
            Guid userGuid = Guid.Parse(userId);
            result.AddRange(Functions.SelectRelevantNoRepeatTasks(userGuid, weekStart));
            result.AddRange(Functions.SelectDailyTasks(userGuid));
            result.AddRange(Functions.SelectWeeklyTasks(userGuid));
            result.AddRange(Functions.SelectRelevantMonthlyTasks(userGuid, weekStart));
            result.AddRange(Functions.SelectRelevantAnnualTasks(userGuid, weekStart));
            response.Content = new StringContent(JsonSerializer.Serialize(result));
            return response;
        }

        public HttpResponseMessage PostTask([FromBody] Task task)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Functions.InsertTask(task).ToString());
            return response;
        }

        public HttpResponseMessage PutTask([FromBody] Task task)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Functions.UpdateTask(task);
            return response;
        }

        public HttpResponseMessage DeleteTask(string taskId)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Functions.DeleteTask(Guid.Parse(taskId));
            return response;
        }
    }
}
