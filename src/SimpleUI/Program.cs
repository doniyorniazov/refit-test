using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Refit;
using SimpleUI.DataAccess;

namespace SimpleUI
{
    //https://localhost:44367
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddRefitClient<IGuestData>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://localhost:44367/api");
            });

            await builder.Build().RunAsync();
        }
    }
}
