using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRPushSQLServer.Startup))]
namespace SignalRPushSQLServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;

            string connectionString = "server=127.0.0.1;Initial Catalog=SignalRTest;Integrated Security=True";
            GlobalHost.DependencyResolver.UseSqlServer(connectionString);
            app.MapSignalR();
          //  app.MapHubs();
            ConfigureAuth(app);

        }
    }
}
