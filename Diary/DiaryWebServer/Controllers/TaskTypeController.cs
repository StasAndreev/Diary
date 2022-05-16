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
        public HttpResponseMessage GetTaskTypes(string userId)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(Functions.SelectTaskTypes(Guid.Parse(userId))));
            return response;
        }

        public HttpResponseMessage PostTaskType([FromBody] TaskType taskType)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Functions.InsertTaskType(taskType).ToString());
            return response;
        }

        public HttpResponseMessage PutTaskType([FromBody] TaskType taskType)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Functions.UpdateTaskType(taskType);
            return response;
        }

        public HttpResponseMessage DeleteTaskType(string taskTypeId)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Functions.DeleteTaskType(Guid.Parse(taskTypeId));
            return response;
        }
    }
}
