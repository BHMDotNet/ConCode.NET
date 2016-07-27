using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;

namespace ConCode.NET.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pfxFile = Path.Combine(Directory.GetCurrentDirectory(), "concode.net.dev.pfx");
            Console.WriteLine($"Loading Cert: ${pfxFile}");
            var cert = new X509Certificate2(pfxFile, "password");

            var host = new WebHostBuilder()
                .UseKestrel(options => {
                        options.UseHttps(cert);
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls("https://*:5000")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
