using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReporteriaMovistar.Tasks.Common;
using ReporteriaMovistar.Tasks.Common.Configuration;
using Serilog;

namespace ReporteriaMovistar.Tasks.SincronizacionEquipo
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
			string nombreApp = typeof(Program).Assembly.GetName().Name.Split(".").Last();

			ConfiguracionLogBase configuracion = new ConfiguracionLogBase(nombreApp);
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.Debug(outputTemplate: ConfiguracionLogBase.PlantillaLog)
				.WriteTo.File(configuracion.RutaArchivo,
				outputTemplate: ConfiguracionLogBase.PlantillaLog,
				rollingInterval: RollingInterval.Minute,
				rollOnFileSizeLimit: true)
				.CreateLogger();

			/*IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();*/

			//NOTE: Esto es sólo una solución temporal, queda pendiente hacer que tome la variable de entorno cuando se publica.
#if DEBUG
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile($"appsettings.Development.json", false, true)
				.AddEnvironmentVariables();
#else
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile($"appsettings.Production.json", false, true)
				.AddEnvironmentVariables();
#endif
			Configuration = configurationBuilder.Build();
			IHost host = CreateHostBuilder(args).Build();

			try
			{
				Log.Information("Aplicación inicializada.");
				await new EquipoService().EjecutarSincronizacionRecepcionAsync();
			}
			catch (Exception excepcion)
			{
				Log.Fatal(excepcion, "Aplicación finalizó inesperadamante.");
			}

			try
			{
				await host.Services.GetRequiredService<EmailNotification>().SendEmailAsync(configuracion.ObtenerRutaArchivoMasReciente());
				return 0;
			}
			catch (Exception excepcion)
			{
				Log.Fatal(excepcion, "Aplicación finalizó inesperadamante.");
				return 1;
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		private static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder()
				.ConfigureServices((_, services) =>
				{
					services.Configure<MailSettings>(Configuration.GetSection("Mail"));
					services.AddScoped<EmailNotification>();
				});
		}
	}
}
