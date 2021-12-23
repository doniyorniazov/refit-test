using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Refit;
using SimpleUI.DataAccess;

namespace SimpleUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddRefitClient<IGuestData>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("http://localhost:9003/api");
            });

            await builder.Build().RunAsync();
        }
    }
}
