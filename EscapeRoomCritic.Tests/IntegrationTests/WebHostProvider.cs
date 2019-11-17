using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using EscapeRoomCritic.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace EscapeRoomCritic.Tests.IntegrationTests
{
    public static class WebHostProvider
    {
        private static TestServer TestServer { get; set; }
        private static string ConnectionString { get; set; }

        public static HttpClient CreateHttpClient()
        {
            ConnectionString = "Server=DESKTOP-TREPOQV\\SQLEXPRESS;Database=EscapeRoomCritic;Trusted_Connection=True;";
            var pathToJson = Path.Combine(
                Directory.GetCurrentDirectory(), "..\\..\\..\\..\\EscapeRoomCritic\\appsettings.json");
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "..\\..\\..\\..\\EscapeRoomCritic"));

                    config.AddJsonFile(pathToJson);
                });
            TestServer = new TestServer(builder);
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(pathToJson, optional: true, reloadOnChange: true);
            ConnectionString = configurationBuilder.Build()["ConnectionStrings:EscapeRoomCriticDatabase"];
            return TestServer.CreateClient();
        }

        public static string GetConnectionString()
        {
            return ConnectionString;
        }


    }
}
