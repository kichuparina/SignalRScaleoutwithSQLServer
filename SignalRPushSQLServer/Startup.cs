﻿using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
[assembly: OwinStartupAttribute(typeof(SignalRPushSQLServer.Startup))]
namespace SignalRPushSQLServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // var hubConfiguration = new HubConfiguration();
           // hubConfiguration.EnableDetailedErrors = true;

            string connectionString = "server=127.0.0.1;Initial Catalog=SignalRTest;Integrated Security=True";
            GlobalHost.DependencyResolver.UseSqlServer(connectionString);
         
          //  app.MapHubs();

            // Branch the pipeline here for requests that start with "/signalr"
            app.Map("/signalr", map =>
            {
                // Setup the CORS middleware to run before SignalR.
                // By default this will allow all origins. You can 
                // configure the set of origins and/or http verbs by
                // providing a cors options with a different policy.
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    // You can enable JSONP by uncommenting line below.
                    // JSONP requests are insecure but some older browsers (and some
                    // versions of IE) require JSONP to work cross domain
                    //EnableJSONP = true
                };
                // Run the SignalR pipeline. We're not using MapSignalR
                // since this branch already runs under the "/signalr"
                // path.

                hubConfiguration.EnableDetailedErrors = true;
                hubConfiguration.EnableJSONP = true;
                map.RunSignalR(hubConfiguration);
            });
            app.MapSignalR();
            ConfigureAuth(app);

        }
    }
}
