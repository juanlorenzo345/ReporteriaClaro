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
using ReporteriaClaro.Clients.ApiPowerBi.Extensions.ApplicationBuilderExtensions;
using ReporteriaClaro.Clients.ApiPowerBi.Extensions.ServiceCollectionExtensions;
using ReporteriaClaro.Clients.ApiPowerBi.Middleware;

namespace ReporteriaClaro.Clients.ApiPowerBi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration 
        { 
	        get;
	        private set;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddDatabaseServices(this.Configuration);
            services.AddControllers();
            services.AddRouting(options =>
            {
	            options.LowercaseUrls = true;
	            options.LowercaseQueryStrings = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Power BI", Version = "v1" });
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
                {
	                Name = "ApiKey",
	                In = ParameterLocation.Header,
	                Type = SecuritySchemeType.ApiKey,
	                Description = "Ingrese su API key en el cuadro de texto.",
	                Scheme = "ApiKeyScheme",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
	                {
		                new OpenApiSecurityScheme()
		                {
			                Reference = new OpenApiReference()
			                {
				                Type = ReferenceType.SecurityScheme,
				                Id = "ApiKey"
			                },
			                In = ParameterLocation.Header
		                },
		                Array.Empty<string>()
	                }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
	        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
		        .SetBasePath(env.ContentRootPath)
		        .AddJsonFile("appsettings.json", true, true)
		        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
		        .AddEnvironmentVariables();

	        Configuration = configurationBuilder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReporteriaClaro.Clients.ApiPowerBi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseApiAuthentication();
            app.UseApiErrorHandler();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
	            endpoints.MapControllers();
            });
        }
    }
}
