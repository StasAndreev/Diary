using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DiaryDbAccess;

namespace DiaryWebServer.Controllers
{
    public class TaskTypeController : ApiController
    {
        public List<TaskType> GetTaskTypes(int userId)
        {
            return Functions.SelectTaskTypes(userId);
        }

        public void PostTaskType(TaskType taskType)
        {
            Functions.InsertTaskType(taskType);
        }

        public void PutTaskType(TaskType taskType)
        {
            Functions.UpdateTaskType(taskType);
        }

        public void DeleteTaskType(int taskTypeId)
        {
            Functions.DeleteTaskType(taskTypeId);
        }
    }
}
