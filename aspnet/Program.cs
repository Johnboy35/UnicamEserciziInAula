using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace aspnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(options => {
                    options.ThreadCount = Environment.ProcessorCount;
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("http://localhost:8080")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
