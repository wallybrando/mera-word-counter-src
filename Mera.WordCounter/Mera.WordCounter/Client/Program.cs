using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mera.WordCounter.Client.Consumers;
using Mera.WordCounter.Client.Helpers;
using Mera.WordCounter.Client.Interfaces.Consumers;
using Mera.WordCounter.Client.Interfaces.Helpers;
using Tewr.Blazor.FileReader;

namespace Mera.WordCounter.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<ITextConsumer, TextConsumer>();
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
        }
    }
}
