using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;

namespace SignalRPushSQLServer.api
{
    public class ApiPushController : ApiController
    {



        [HttpPost]
        public HttpResponseMessage Push(Push push)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.Client(push.clientID).push(push.message);
            return new HttpResponseMessage(){ Content = new JsonContent(new{ Flag = true})};
        }
    }

   public class Push
    {

       public String clientID { get; set; }
       public string message { get; set; }
    }
}
