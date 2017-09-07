using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRPushSQLServer
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.  
            Clients.All.broadcastMessage(name, message);
        }

        public void Send(string name, string message, string connID)
        {
            Clients.Client(connID).push("senti");

            ///Clients.User(connID).push("senti");
        }
             
    }
}