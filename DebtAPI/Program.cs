using Core;
using DataAccessLibrary;
using DataAccessLibrary.Data.API;
using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using DebtAPI.Hangfire;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                string recalculationJob = "RecalculateJob";
                string APIjob = "APIJob";
                using (var context = provider.GetRequiredService<DebtContext>())
                {
                    context.Database.Migrate();
                }
                RecurringJob.AddOrUpdate<HangfireActions>(recalculationJob,
                    x=>x.RecalculateGrowth(), Cron.Hourly);
                RecurringJob.AddOrUpdate<HangfireActions>(APIjob,
                    x => x.GetDataFromAPIAndPutItIntoDB(), Cron.Weekly);
                RecurringJob.Trigger(recalculationJob);
                RecurringJob.Trigger(APIjob);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
