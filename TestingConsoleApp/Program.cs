using Autofac;
using DataAccessLibrary;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace TestingConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var db = scope.Resolve<IDebtData>();
            }
        }
       
    }
}
