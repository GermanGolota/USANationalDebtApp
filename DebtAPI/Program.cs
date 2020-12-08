using DataAccessLibrary;
using DataAccessLibrary.Data.API;
using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.DbModels;
using Microsoft.AspNetCore.Hosting;
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
            host.Run();
        }
        public static async Task GetDataFromAPIAndPutItIntoDB(IApiDataManager api, IDebtData debtData)
        {
            List<DebtModel> models = await api.GetDebtModels();
            foreach (var model in models)
            {
                await debtData.AddDebtToDB(model);
            }
        }
        public static async Task RecalculateGrowth(IDebtData debtData)
        {
            await debtData.CalculateAndInsertNewInfo();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
