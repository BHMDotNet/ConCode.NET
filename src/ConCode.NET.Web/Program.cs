using System.IO;
using Microsoft.AspNetCore.Hosting;
using ConCode.NET.Core.Data;
using Newtonsoft.Json;

namespace ConCode.NET.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
