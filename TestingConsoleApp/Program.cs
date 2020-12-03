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
            //bridge test
           /* var container = ContainerConfig.Configure();
           
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
            }*/
            //config test
            IConfiguration conf = new MockConfiguration();
            Console.WriteLine(conf.GetConnectionString("Standard"));
            
        }
    }
}
