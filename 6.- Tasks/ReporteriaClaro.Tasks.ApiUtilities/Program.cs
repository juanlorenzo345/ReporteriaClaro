using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ReporteriaClaro.Tasks.ApiUtilities.Services;
using Serilog;

namespace ReporteriaClaro.Tasks.ApiUtilities
{
    class Program
    {
	    internal static IConfiguration Configuration
	    {
		    get;
		    private set;
	    }

        static async Task<int> Main(string[] args)
         {
			/*IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
		        .SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, false)
				.AddEnvironmentVariables();*/

#if DEBUG
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile($"appsettings.Development.json", false, true)
				.AddEnvironmentVariables();
#else
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile($"appsettings.Production.json", false, true)
				.AddEnvironmentVariables();
#endif
	        Configuration = configurationBuilder.Build();
			Log.Logger = new LoggerConfiguration()
		        .ReadFrom.Configuration(Configuration)
		        .CreateBootstrapLogger();

			CreateHostBuilder(args).Build();

			try
	        {
		        Log.Information("Iniciando web host...");
		        Console.WriteLine("CREACIÓN DE USUARIOS PARA API REPORTERÍA CLARO");
		        await new UsuarioApiService().CrearUsuarioAsync();
		        Console.WriteLine("Presione una tecla para finalizar...");
		        Console.ReadKey();
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
		        .Enrich.FromLogContext());
	}
}
