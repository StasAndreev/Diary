﻿using System;
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
        public List<Task> GetWeekTasks(int userId, DateTime weekStart)
        {
            List<Task> result = new List<Task>();
            result.AddRange(Functions.SelectRelevantNoRepeatTasks(userId, weekStart));
            result.AddRange(Functions.SelectDailyTasks(userId));
            result.AddRange(Functions.SelectWeeklyTasks(userId));
            result.AddRange(Functions.SelectRelevantMonthlyTasks(userId, weekStart));
            result.AddRange(Functions.SelectRelevantAnnualTasks(userId, weekStart));
            return result;
        }

        public void PostTask(Task task)
        {
            Functions.InsertTask(task);
        }

        public void PutTask(Task task)
        {
            Functions.UpdateTask(task);
        }

        public void DeleteTask(int taskId)
        {
            Functions.DeleteTask(taskId);
        }
    }
}