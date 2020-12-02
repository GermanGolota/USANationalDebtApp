using Autofac;
using DataAccessLibrary;
using DataAccessLibrary.Data.Api;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;



namespace TestingConsoleApp
{
    public static class ContainerConfig
    {
        public static IContainer Configure() 
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<ConfigurationExtensions>().As<IConfiguration>();

            builder.RegisterType<DebtData>().As<IDebtData>();
            builder.RegisterType<MockConfiguration>().As<IConfiguration>();
            builder.RegisterType<MockApiDataManager>().As<IApiDataManager>();
            builder.RegisterType<MySQLDataAccess>().As<ISQLDataAccess>();
            builder.RegisterType<APISQLBridge>().As<IAPISQLBridge>();


            return builder.Build();
        }
    }
}
