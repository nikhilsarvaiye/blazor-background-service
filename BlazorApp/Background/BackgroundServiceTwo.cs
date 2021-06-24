using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp.Background
{
    public class BackgroundServiceTwo : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Running Background Service Two");

                await Task.Delay(50, stoppingToken);
                
                // BackgroundServiceOne.LaserOperation.WriteFrame0Data();
            }
        }
    }
}
