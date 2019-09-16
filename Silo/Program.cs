using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Hosting;
using Orleans.Logging;

namespace Silo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var siloHostBuilder = new SiloHostBuilder()
                .UseLocalhostClustering(serviceId: "localhostCart")
                .AddAdoNetGrainStorage("OrleansStorage", options =>
                {
                    options.Invariant = "";
                    options.UseJsonFormat = true;
                    options.ConnectionString = "Server=.;Database=OrleansDemo;Trusted_Connection=True;";
                })
                .ConfigureLogging(x=>x.AddConsole())
                .UseDashboard();
            using (var host=siloHostBuilder.Build())
            {
                await host.StartAsync();
                Console.ReadLine();
            }
        }
    }
}
