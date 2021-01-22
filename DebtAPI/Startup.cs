using Core;
using DataAccessLibrary;
using DataAccessLibrary.Data.API;
using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using DataAccessLibrary.Models.ApiModels;
using DebtAPI.Hangfire;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //allows webassembly app to access
            services.AddCors(
                (options) =>
                {
                    options.AddPolicy(name: "WebAssemblyAppPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });

            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["Password"] ?? "Password123";
            var debtDB = Configuration["DBName"] ?? "UsaDebtsDb";
            string connectionString = $"Server={server},{port};Initial Catalog={debtDB};" +
                $"User ID={user};Password={password}";
            services.AddControllers();
            //adds API
            services.AddScoped<IModelConverter, ModelConverter>();
            services.AddScoped<IAPIClient, APIClient>();
            services.AddScoped<IApiDataManager, DebtAPIDataManager>();
            //dbContext
            services.AddDbContext<DebtContext>(
                opt => opt.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(nameof(DataAccessLibrary))));
            //Adds repos
            services.AddScoped<IClientRepo, EFClientRepo>();
            services.AddScoped<ISystemRepo, EFDebtRepo>();
            //adds swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DebtAPI", Version = "v1" });
            });
            Console.WriteLine($"Connection to - {debtDB} on {connectionString}");
            var options = new SqlServerStorageOptions();
            options.SchemaName = "hangfire_db";
            options.PrepareSchemaIfNecessary = true;
            GlobalConfiguration.Configuration
                .UseSqlServerStorage(connectionString, options);

            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(connectionString, options);
            });
            JobStorage.Current = new SqlServerStorage(connectionString, options);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            //adds configuration, that allows for dependency injection
            GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(serviceProvider));

            app.UseHangfireServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DebtAPI v1"));
                app.UseHangfireDashboard();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("WebAssemblyAppPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
