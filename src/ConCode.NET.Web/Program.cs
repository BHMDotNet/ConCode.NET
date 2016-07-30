using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace ConCode.NET.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var speakers = File.ReadAllText("Speakers.json", Encoding.UTF8);

            Console.WriteLine(speakers);


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
