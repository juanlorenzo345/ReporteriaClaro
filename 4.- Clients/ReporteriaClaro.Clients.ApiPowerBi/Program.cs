using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace ReporteriaClaro.Clients.ApiPowerBi
{
    public class Program
    {
        public static int Main(string[] args)
        {
	        IConfiguration configuracion = new ConfigurationBuilder()
		        .SetBasePath(Directory.GetCurrentDirectory())
		        .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
		        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
		        .Build();

	        Log.Logger = new LoggerConfiguration()
		        .ReadFrom.Configuration(configuracion)
		        .CreateBootstrapLogger();

	        try
	        {
		        Log.Information("Iniciando web host...");
		        CreateHostBuilder(args).Build().Run();
		        return 0;
	        }
	        catch (Exception excepcion)
	        {
		        Log.Fatal(excepcion, "Host terminó inesperadamante.");
		        return 1;
	        }
	        finally
	        {
		        Log.CloseAndFlush();
	        }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
			    .UseSerilog((context, services, configuration) => configuration
			    .ReadFrom.Configuration(context.Configuration)
			    .ReadFrom.Services(services)
			    .Enrich.FromLogContext())
			    .ConfigureWebHostDefaults(webBuilder =>
			    {
			        webBuilder.UseStartup<Startup>();
			    });
    }
}
