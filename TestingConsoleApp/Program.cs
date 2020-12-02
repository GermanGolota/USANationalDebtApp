using Autofac;
using DataAccessLibrary;
using Microsoft.Extensions.Configuration;
using System;

namespace TestingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var bridge = scope.Resolve<IAPISQLBridge>();
                try
                {
                    bridge.AddDataFromAPIToDb();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            }
        }
    }
}
