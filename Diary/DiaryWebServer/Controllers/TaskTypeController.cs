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
        public List<TaskType> GetTaskTypes(Guid userId)
        {
            return Functions.SelectTaskTypes(userId);
        }

        public Guid PostTaskType(TaskType taskType)
        {
            return Functions.InsertTaskType(taskType);
        }

        public void PutTaskType(TaskType taskType)
        {
            Functions.UpdateTaskType(taskType);
        }

        public void DeleteTaskType(Guid taskTypeId)
        {
            Functions.DeleteTaskType(taskTypeId);
        }
    }
}
