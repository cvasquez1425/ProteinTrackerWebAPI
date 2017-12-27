using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace ProteinTrackerWebAPI
{
    public class Program
    {
        /// <summary>
        /// this boilerplate code yo won't need to change very often.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)  // this is where our app is starting up. This is the starting point of all your code.
        {
            var host = new WebHostBuilder()     // listen to our app.
                .UseKestrel()                   // name of the web server under ASP.NET Core
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
