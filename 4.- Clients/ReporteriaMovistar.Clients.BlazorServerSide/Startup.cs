using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReporteriaMovistar.Clients.BlazorServerSide.Areas.Identity;
using ReporteriaMovistar.Clients.BlazorServerSide.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDownloadFile;
using ReporteriaMovistar.Clients.BlazorServerSide.Extensions.ServiceCollectionExtensions;
using Serilog;

namespace ReporteriaMovistar.Clients.BlazorServerSide
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
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddRazorPages();
	        services.AddServerSideBlazor();
            services.AddDatabaseServices(this.Configuration);
	        services.AddAuthenticationServices();
	        services.AddValidationServices();
	        services.AddInfrastructureServices();
	        services.AddComponentLibraryServices();
	        services.AddBlazorDownloadFile();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
	        //NOTE: Se agregó esta línea para poder cambiar fácilmente entre ambiente de desarrollo y ambiente de producción.
	        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
		        .SetBasePath(env.ContentRootPath)
		        .AddJsonFile("appsettings.json", true, true)
		        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
		        .AddEnvironmentVariables();

	        Configuration = configurationBuilder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
