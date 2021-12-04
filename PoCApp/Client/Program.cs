using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PoCApp.Client.Contracts;
using PoCApp.Client.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazoredLocalStorage();
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IPocService, PocService>();


           var apiUrl = new Uri(builder.Configuration["apiUrl"]);

            void RegisterTypeClient<TClient, TImplementation>(Uri apiBaseUrl)
                where TClient : class
                where TImplementation : class,
                TClient
            {
                builder.Services.AddHttpClient<TClient, TImplementation>(client =>
                {
                    client.BaseAddress = apiBaseUrl;

                });//.AddHttpMessageHandler<ValidateHeaderHandler>();


            }
            RegisterTypeClient<IHttpService, HttpService>(apiUrl);


            await builder.Build().RunAsync();
        }
    }
}
