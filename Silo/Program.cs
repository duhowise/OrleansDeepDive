using System;
using System.Threading.Tasks;
using GrainInterfaces;
using Grains;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Hosting;

namespace Silo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var siloHostBuilder = new SiloHostBuilder()
               
                .UseLocalhostClustering(serviceId: "localhostCart")
                .AddAdoNetGrainStorage("CartStorage", storageOptions =>
                {
                    storageOptions.Invariant = "System.Data.SqlClient";
                    storageOptions.UseJsonFormat = true;
                    storageOptions.ConnectionString = "Server=.;Database=OrleansDemo;Trusted_Connection=True;";
                })
                .ConfigureApplicationParts(parts =>
                    parts.AddApplicationPart(typeof(CartGrain).Assembly).WithReferences())
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
