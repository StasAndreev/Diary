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
        [Route("api/task/{userId}/{weekStart}")]
        public HttpResponseMessage GetWeekTasks(Guid userId, DateTime weekStart)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            List<Task> result = new List<Task>();
            result.AddRange(Functions.SelectRelevantNoRepeatTasks(userId, weekStart));
            result.AddRange(Functions.SelectDailyTasks(userId));
            result.AddRange(Functions.SelectWeeklyTasks(userId));
            result.AddRange(Functions.SelectRelevantMonthlyTasks(userId, weekStart));
            result.AddRange(Functions.SelectRelevantAnnualTasks(userId, weekStart));
            response.Content = new StringContent(JsonSerializer.Serialize(result));
            return response;
        }

        public HttpResponseMessage PostTask(Task task)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Functions.InsertTask(task).ToString());
            return response;
        }

        public HttpResponseMessage PutTask(Task task)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Functions.UpdateTask(task);
            return response;
        }

        public HttpResponseMessage DeleteTask(Guid taskId)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Functions.DeleteTask(taskId);
            return response;
        }
    }
}
