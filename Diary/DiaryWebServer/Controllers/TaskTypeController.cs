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
    public class TaskTypeController : ApiController
    {
        public HttpResponseMessage GetTaskTypes(Guid userId)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(Functions.SelectTaskTypes(userId)));
            return response;
        }

        public HttpResponseMessage PostTaskType(TaskType taskType)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Functions.InsertTaskType(taskType).ToString());
            return response;
        }

        public HttpResponseMessage PutTaskType(TaskType taskType)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Functions.UpdateTaskType(taskType);
            return response;
        }

        public HttpResponseMessage DeleteTaskType(Guid taskTypeId)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Functions.DeleteTaskType(taskTypeId);
            return response;
        }
    }
}
