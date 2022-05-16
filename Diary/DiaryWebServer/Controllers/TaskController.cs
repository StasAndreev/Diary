using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DiaryDbAccess;

namespace DiaryWebServer.Controllers
{
    public class TaskController : ApiController
    {
        [Route("api/task/{userId}/{weekStart}")]
        public List<Task> GetWeekTasks(Guid userId, DateTime weekStart)
        {
            List<Task> result = new List<Task>();
            result.AddRange(Functions.SelectRelevantNoRepeatTasks(userId, weekStart));
            result.AddRange(Functions.SelectDailyTasks(userId));
            result.AddRange(Functions.SelectWeeklyTasks(userId));
            result.AddRange(Functions.SelectRelevantMonthlyTasks(userId, weekStart));
            result.AddRange(Functions.SelectRelevantAnnualTasks(userId, weekStart));
            return result;
        }

        public Guid PostTask(Task task)
        {
            return Functions.InsertTask(task);
        }

        public void PutTask(Task task)
        {
            Functions.UpdateTask(task);
        }

        public void DeleteTask(Guid taskId)
        {
            Functions.DeleteTask(taskId);
        }
    }
}
