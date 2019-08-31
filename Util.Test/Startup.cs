using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using Topshelf;

[assembly: OwinStartup(typeof(Util.Test.Startup))]
namespace Util.Test
{
    public class Startup : ServiceControl
    {
       
        private string hostsetting;
        private IDisposable Signalr { get; set; }
        public Startup(string hostsetting)
        {
            this.hostsetting = hostsetting;
        }
        public bool Start(HostControl hostControl)
        {
            try
            {
                using (
                  Signalr = WebApp.Start("http://+:9010/", app =>
              {
                  app.UseCors(CorsOptions.AllowAll);

                //app.Map("/api/Health", taskapp =>
                //{
                //    taskapp.Run(async (context) =>
                //    {
                //        using (var client = new HttpClient())
                //        {
                //            var result = client.GetAsync("http://123.233.116.37:8082/sysManage/Account/Login").Result;

                //            context.Response.ContentType = "text/plain";
                //          await   context.Response.WriteAsync("Hello, world!");
                //        }
                //    });
                //});

            })) ;
            }
            catch (Exception ex) {
                Console.WriteLine("ERROR"+ex.Message);
                Console.ReadLine();
            }
            return true;
        
        }

        public bool Stop(HostControl hostControl)
        {
            throw new System.NotImplementedException();
        }


        
       
    }
}
