using Microsoft.Extensions.Hosting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp.Background
{
    public class BackgroundServiceOne : BackgroundService
    {
        public static LaserOperations LaserOperation { get; set; } = new();

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // LaserOperations.ReadWriteThreadsInit();
            await Task.Delay(100, stoppingToken);
            
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Running Background Service One");
                await Task.Delay(50, stoppingToken);

                // LaserOperation.Read();
            }
        }
    }
}
