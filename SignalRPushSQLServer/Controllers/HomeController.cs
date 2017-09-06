using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;

namespace SignalRPushSQLServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string msg)
        {
            ViewBag.Message = "Your contact page.";
          //  new ChatHub().Send("esty", "test");

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.broadcastMessage("Admin", msg);
            return View();
        }
    }
}