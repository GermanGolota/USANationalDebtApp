using Autofac;
using DataAccessLibrary;
using DebtAPI;
using DebtAPI.DB;
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

           
            builder.RegisterType<MockConfiguration>().As<IConfiguration>();
            builder.RegisterType<EFDebtRepo>().As<IDebtData>();
            builder.RegisterType<DebtContext>();
            /*
            builder.RegisterType<ClientAccess>().As<IClientAccess>();
            
            builder.RegisterType<DebtAPI>().As<IApiDataManager>();
            builder.RegisterType<MySQLDataAccess>().As<ISQLDataAccess>();
            builder.RegisterType<APISQLBridge>().As<IAPISQLBridge>();
            builder.RegisterType<ModelConverter>().As<IModelConverter>();
            builder.RegisterType<DebtAPI>().As<IApiDataManager>();
            builder.RegisterType<APIClient>().As<IAPIClient>() ;*/

            return builder.Build();
        }
    }
}
