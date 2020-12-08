using DataAccessLibrary;
using DataAccessLibrary.Data.DB;
using DataAccessLibrary.Models;
using DebtAPI.DB;
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
                        builder.WithOrigins("https://localhost:44394", "https://localhost:5001")
                          .WithMethods("GET");
                    });
                });


            services.AddControllers();
            //adds API
            services.AddScoped<IModelConverter, ModelConverter>();
            services.AddScoped<IAPIClient, APIClient>();
            services.AddScoped<IApiDataManager, DebtAPIDataManager>();
            //dbContext

            services.AddDbContext<DebtContext>(
                opt=>opt.UseSqlServer(Configuration.GetConnectionString("Standard")));

            //Adds repos
            services.AddScoped<IClientAccess, EFClientRepo>();
            services.AddScoped<IDebtData, EFDebtRepo>();
            //adds swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DebtAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DebtAPI v1"));
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
