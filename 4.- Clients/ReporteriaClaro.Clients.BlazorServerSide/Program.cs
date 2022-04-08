#region Header
//  ---------------------------------------------------------------------------------------------------
// |                                                                                                   |
// |             __                         __               __       ______ __     _  __              |
// |            / /   ____   ____ _ __  __ / /_ ___   _____ / /_     / ____// /_   (_)/ /___           |
// |           / /   / __ \ / __ `// / / // __// _ \ / ___// __ \   / /    / __ \ / // // _ \          |
// |          / /___/ /_/ // /_/ // /_/ // /_ /  __// /__ / / / /  / /___ / / / // // //  __/          |
// |         /_____/\____/ \__, / \__, / \__/ \___/ \___//_/ /_/   \____//_/ /_//_//_/ \___/           |
// |                      /____/ /____/                                                                |
// |                                                                                                   |
//  ---------------------------------------------------------------------------------------------------
// 
// Usuario: cristian.ulloa
// Solución/Proyecto: ReporteriaClaro / ReporteriaClaro.Clients.BlazorServerSide
// Info archivo:
//     Nombre: Program.cs
//     Fecha creación: 2021/10/22 at 05:59 PM
//     Fecha modificación: 2021/10/25 at 09:53 AM
// 
// Creado usando Visual Studio 2019 Community IDE
// ----------------------------------------------****.****----------------------------------------------
#endregion

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using Serilog;

namespace ReporteriaClaro.Clients.BlazorServerSide
{
	public class Program
    {
	    #region Methods

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

	    public static int Main(string[] args)
        {
			IConfiguration configuracion = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
			.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Machine)}.json", optional: true)
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

	    #endregion
    }
}
