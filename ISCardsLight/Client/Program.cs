using ISCardsLight.PageModels;
using ISCardsLight.Services.PassengerCardServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ISCardsLight
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //Add Services
            services.AddTransient<IPassengerCardService, PassengerCardService>();
            //Add PageModels
            var serviceProvider = services.BuildServiceProvider();

            services.AddTransient<PassengerCardPageModel>();

            await builder.Build().RunAsync();
        }
    }
}