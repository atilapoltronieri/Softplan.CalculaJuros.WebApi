using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Softplan.CalculaJuros.WebApi;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Softplan.CalculaJuros.Test.Fixture
{
    public class WebHosterFixture : IWebHosterFixture, IDisposable
    {

        public HttpClient Client { get; }
        public IServiceProvider Services { get; }

        public WebHosterFixture()
        {
            var builder = new WebHostBuilder()
                 .UseConfiguration(new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json")
                     .Build()
                 )
                 .UseStartup<Startup>().UseEnvironment("Test");

            var testServer = new TestServer(builder);
            Client = testServer.CreateClient();
            Services = testServer.Host.Services;

        }


        public T Resolve<T>() => (T)Services.GetService(typeof(T));

        public void Dispose()
        {
            Client.Dispose();
        }
    }

    public interface IWebHosterFixture
    {
        HttpClient Client { get; }
        T Resolve<T>();
    }
}
