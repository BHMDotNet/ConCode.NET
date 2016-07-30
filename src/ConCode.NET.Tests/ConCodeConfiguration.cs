using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConCode.NET.Tests
{
    public class ConCodeConfiguration
    {
        static ConCodeConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory + "\\..\\..\\..\\")
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .AddUserSecrets();

            var c = config.Build();
            Config = c;
        }
        public static IConfigurationRoot Config { get; set; }
    }
}
