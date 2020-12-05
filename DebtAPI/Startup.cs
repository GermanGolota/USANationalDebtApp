using DataAccessLibrary;
using DataAccessLibrary.Data.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
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

            services.AddScoped<ClientAccess>();
            services.AddScoped<IClientAccess>(
                (x) => { return x.GetRequiredService<ClientAccess>(); }
                );
            services.AddScoped<MySQLDataAccess>();
            services.AddScoped<ISQLDataAccess>(
                (x) => { return x.GetRequiredService<MySQLDataAccess>(); }
                );


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
